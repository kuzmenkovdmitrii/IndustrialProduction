namespace WEB
{
    public class CustomRegularExpression
    {
        public const string PHONE_PATTERN =
            @"^\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*$";

        public const string PASSWORD_PATTERN =
            @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$";
    }
}