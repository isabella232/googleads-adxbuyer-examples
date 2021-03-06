﻿/* Copyright 2014, Google Inc. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.Apis.AdExchangeBuyer.v1_4;
using Google.Apis.AdExchangeBuyer.v1_4.Data;
using Google.Apis.Services;

using System;

namespace Google.Apis.AdExchangeBuyer.Examples.v1_x
{
    /// <summary>
    /// Retrieves the authenticated user's list of performance metrics.
    /// </summary>
    public class ListPerformanceReports : ExampleBase
    {
        /// <summary>
        /// Main method, to run this code example as a standalone application.
        /// </summary>
        /// <param name="args">The command line arguments</param>
        public static void Main(string[] args)
        {
            AdExchangeBuyerService service = Utilities.GetV1Service();
            ExampleBase example = new ListPerformanceReports();
            Console.WriteLine(example.Description);
            example.Run(service);
        }

        /// <summary>
        /// Returns a description about the code example.
        /// </summary>
        public override string Description
        {
            get { return "This code example lists all performance reports for the account."; }
        }

        /// <summary>
        /// Runs the code example.
        /// </summary>
        /// <param name="service">An authenticated AdExchangeBuyerService</param>
        public override void Run(BaseClientService service)
        {
            AdExchangeBuyerService adXService = (AdExchangeBuyerService)service;
            int accountId = int.Parse("INSERT ACCOUNT ID HERE");
            // Date report should start - mm/dd/yyyy format - oldest date
            string reportStartDate = "1/1/2014";
            // Date report should end - mm/dd/yyyy format - most recent date
            string reportEndDate = "4/1/2014";

            PerformanceReportList allReports = adXService.PerformanceReport.List(accountId,
                reportEndDate, reportStartDate).Execute();

            if (allReports.PerformanceReport == null)
            {
                Console.WriteLine("No performance reports associated with this user");
            }
            else
            {
                foreach (PerformanceReport report in allReports.PerformanceReport)
                {
                    Console.WriteLine("Region:", report.Region);
                    Console.WriteLine("\tTime Stamp:", report.Timestamp);
                    Console.WriteLine("\tPixel Match Requests:", report.PixelMatchRequests);
                    Console.WriteLine("\tPixel Match Responses:", report.PixelMatchResponses);
                }
            }
        }

        public override ClientType getClientType()
        {
            return ClientType.ADEXCHANGEBUYER;
        }
    }
}