﻿using System;
using System.Collections.Generic;
using iayos.intrinioapi.ServiceModel.Dtos;
using iayos.intrinioapi.ServiceModel.Enums;
using ServiceStack;

namespace iayos.intrinioapi.ServiceModel.Messages
{

	[Route("/fundamentals/standardized", HttpMethods.Get)]
	public class GetStandardizedFundamentals : Request, IReturn<GetStandardizedFundamentalsResponse> 
	{

		/// <summary>
		/// the stock market ticker symbol associated with the companies common stock securities: TICKER SYMBOL
		/// </summary>
		public string identifier { get; set; }

		/// <summary>
		/// the financial statement requested, options include the income statement, balance sheet, statement of cash 
		/// flows and calculated metrics and ratios: income_statement | balance_sheet | cash_flow_statement | calculations
		/// </summary>
		public FinancialStatement statement { get; set; }

		/// <summary>
		/// (optional, returns all available fundamentals) - the type of periods requested - includes fiscal years for 
		/// annual data, quarters for quarterly data and trailing twelve months for annual data on a quarterly basis: FY | QTR | TTM | YTD
		/// </summary>
		public HistoricalDataType? type { get; set; }

		/*
		 * sequence (required, only in Excel add-in function) - an integer 0 or greater for calling a single fundamental from the first entry, most recent first: 0..last available
		 */

		/*
		 * item (required, only in Excel add-in function) - the return value for the fundamental: fiscal_year | fiscal_period | end_date | start_date
		 */

		/// <summary>
		/// (optional, default is today) - the first fundamental will be the latest as of this specified date: YYYY-MM-DD
		/// </summary>
		/// <seealso cref="Date_IaYoS"/>
		public string date => Date_IaYoS != null ? Date_IaYoS.GetValueOrDefault().ToString("YYYY-MM-DD") : null;

		/// <summary>
		/// Conveniently set date using actual date object
		/// </summary>
		/// <seealso cref="date"/>
		public DateTime? Date_IaYoS { get; set; }

	}

	public class GetStandardizedFundamentalsResponse : Response<List<StandardizedFundamentalsDto>>
	{
	}
}
 