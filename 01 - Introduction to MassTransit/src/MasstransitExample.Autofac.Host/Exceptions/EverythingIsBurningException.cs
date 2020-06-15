using System;

namespace MasstransitExample.Autofac.Host
{
    public class EverythingIsBurningException : Exception
    {
        public EverythingIsBurningException() : base("Everything crashed. No retries will be done")
        {
            
        }
    }
}