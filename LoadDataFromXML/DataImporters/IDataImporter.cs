namespace LoadDataFromXML
{
    using System.Collections.Generic;

    public interface IDataImporter<T>
    {
        void ImportOrdersData(ICollection<T> orders);
    }
}