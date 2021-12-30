using System;

namespace Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, string entity)
        {

        }
    }
}
