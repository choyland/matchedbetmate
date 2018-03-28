using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MatchedBetMate.iOS.ViewModels.Base
{
    public class BaseViewModel
    {
        protected async Task<bool> ExecuteWithNetworkHandling(Func<Task> action)
        {
            var success = true;

            try
            {
                await action();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                success = false;
            }

            return success;
        }
    }
}