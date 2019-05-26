namespace NP_CompleteOrder
{
    public static class DecimalExtension
    {
        public static decimal RoundUp(this decimal input)
        {
            if(input > (int)input)
            {
                input++;
            }
            return (int)input;
        }
        public static decimal RoundDown(this decimal input)
        {
            return (int)input;
        }
    }
}
