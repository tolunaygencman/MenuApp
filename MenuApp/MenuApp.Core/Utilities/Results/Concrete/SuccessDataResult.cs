﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>, IDataResult<T> where T : class
    {
        public SuccessDataResult() : base(default, true)
        { }
        public SuccessDataResult(string message) : base(default, true, message)
        { }
        public SuccessDataResult(T data, string message) : base(data, true, message)
        { }
    }
}
