﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI.Web.Models
{
    /// <summary>
    /// Class that encapsulates most common parameters sent by DataTables plugin
    /// </summary>
    public class jQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>       
        public string sEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string[] search { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns { get; set; }
    }
}