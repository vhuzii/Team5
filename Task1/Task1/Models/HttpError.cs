namespace Task1.Models
{
    using System;

    internal class HttpError : IComparable<HttpError>
    {
        public int ErrorCode { get; set; }

        public string Description { get; set; }

        public int CompareTo(HttpError obj)
        {
            return this.ErrorCode.CompareTo(obj.ErrorCode);
        }

        public override bool Equals(object obj)
        {
            var item = obj as HttpError;

            if (item == null)
            {
                return false;
            }

            return this.ErrorCode.Equals(item.ErrorCode);
        }

        public override int GetHashCode()
        {
            return this.ErrorCode.GetHashCode();
        }
    }
}
