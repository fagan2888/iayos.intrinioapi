﻿using System.Collections.Generic;
using iayos.intrinioapi.ServiceModel.Enums;
using iayos.intrinioapi.ServiceModel.Messages;
using ServiceStack.Configuration;
using Xunit;

namespace iayos.intrinioapi.Api.Test
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}


	public class IntrinioApiTests
	{
		private readonly IntrinioClient _client;


		public IntrinioApiTests()
		{
			var username = ConfigUtils.GetAppSetting("intrinio:username");
			var password = ConfigUtils.GetAppSetting("intrinio:password"); ;

			_client = new IntrinioClient(username, password);
		}


		[Fact]
		public void CanQueryMasterDataListForCompanies()
		{
			// Currently working
			var getCompaniesResponse = _client.GetMasterCompaniesList(new GetCompaniesMasterList { });
		}


		[Fact]
		public void CanQueryMasterDataListForSecurities()
		{
			// Currently failing because empty parameter values cause internal server error
			var getSecuritiesResponse = _client.GetMasterSecuritiesList(new GetSecuritiesMasterList { });
		}


		[Fact]
		public void CanQueryMasterDataListForIndices()
		{
			// Currently working
			var getIndicesResponse = _client.GetMasterIndicesList(new GetIndicesMasterList { });
		}


		[Fact]
		public void CanQueryMasterDataListForOwners()
		{
			// Currently failing with error about insufficient permissions
			var getOwnerResponse = _client.GetMasterOwnersList(new GetOwnersMasterList { });
		}


		[Fact]
		public void CanGetCompanyDetails()
		{
			var request = new GetCompanyDetails
			{

			};
			var response = _client.GetCompanyDetails(request);
		}


		[Fact]
		public void CanGetSecurityDetails()
		{
			var request = new GetSecurityDetails
			{

			};
			var response = _client.GetSecurityDetails(request);
		}

		[Fact]
		public void CanGetIndexDetails()
		{
			var request = new GetIndexDetails
			{

			};
			var response = _client.GetIndexDetails(request);
		}


		[Fact]
		public void CanSearchSecuritiesWithConditions()
		{
			var searchSecuritiesRequest = new SearchSecurities
			{
				page_size = 1,
				Conditions_IaYoS = new List<SecuritiesSearchCondition>
				{
					new SecuritiesSearchCondition {Operator = SearchOperator.gt, Tag = DataPointTag.accruedexpenses, Value = 0.01}
				}
			};
			var companyDetails = _client.SearchSecurities(searchSecuritiesRequest);
		}


		[Fact]
		public void CanSearchDataPoints()
		{
			var datapointRequest = new SearchDataPoints { };
			datapointRequest.Identifers.Add("AAPL");
			datapointRequest.Tags.Add(DataPointTag.accruedexpenses);
			datapointRequest.Tags.Add(DataPointTag.acquisitions);
			var datapointResponse = _client.SearchDataPoints(datapointRequest);
		}


		[Fact]
		public void CanSearchHistoricalData()
		{
			var historicalDataRequest = new SearchHistoricalData { };
			var response = _client.SearchHistoricalData(historicalDataRequest);
		}


		[Fact]
		public void CanGetPrices()
		{
			var request = new GetPrices { identifier = "AAPL" };
			var response = _client.GetPrices(request);
		}




		//[Fact]
		//public void DoSomeStuff()
		//{
		//	try
		//	{
		//	}
		//	catch (WebServiceException webEx)
		//	{
		//		// TODO Inspect the webEx to see what went wrong:
		//		var errorMessage = webEx.ErrorMessage;
		//		/*
		//		 * Example error response:
		//		  webEx.StatusCode        = 400
		//		  webEx.StatusDescription = ArgumentNullException
		//		  webEx.ErrorCode         = ArgumentNullException
		//		  webEx.ErrorMessage      = Value cannot be null. Parameter name: Name
		//		  webEx.StackTrace        = (your Server Exception StackTrace - in DebugMode)
		//		  webEx.ResponseDto       = (your populated Response DTO)
		//		  webEx.ResponseStatus    = (your populated Response Status DTO)
		//		  webEx.GetFieldErrors()  = (individual errors for each field if any)
		//		*/
		//	}
		//}

	}
}
