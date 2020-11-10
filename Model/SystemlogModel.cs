using System;
using System.Collections.Generic;

namespace Model
{
    public class SystemlogModel
    {
        public string systemlogid { get; set; }
        public string acountid { get; set; }
        public string descriptionaction { get; set; }
        public DateTime? logdate { get; set; }
    }
}
