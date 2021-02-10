using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string messagge) : base(false, messagge)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}
