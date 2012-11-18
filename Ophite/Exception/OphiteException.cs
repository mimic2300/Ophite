
namespace Ophite.Exception
{
    public class OphiteException : System.Exception
    {
        public OphiteException()
            : base()
        { 
        
        }

        public OphiteException(string message) 
            : base(message)
        {

        }

        public OphiteException(string message, System.Exception innerException)
            : base(message, innerException)
        { 
        
        }
    }
}
