using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {

        public SuccessResult(string messagge) : base(true, messagge)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
