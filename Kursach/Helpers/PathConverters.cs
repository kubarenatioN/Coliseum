namespace Kursach
{
    public static class PathConverters
    {
        /// <summary>
        /// Method to prepend zero to number
        /// </summary>
        /// <param name="num"></param>
        /// <returns name="avatarColorNumber"></returns>
        public static string CheckDigits(int num)
        {
            string avatarColorNumber;
            if (num < 10)
            {
                avatarColorNumber = "0" + num.ToString();
            }
            else
            {
                avatarColorNumber = num.ToString();
            }
            return avatarColorNumber;
        }
    }
}
