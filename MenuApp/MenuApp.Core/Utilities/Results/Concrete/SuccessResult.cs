using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Core.Utilities.Results.Concrete
{
    public class SuccessResult
    {
        public SuccessResult() : base(true)
        { }
        public SuccessResult(string message) : base(true, message)
        { }
    }
}
