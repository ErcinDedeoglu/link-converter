namespace TY.LinkConverter.Data.Interface
{
    public interface ILinkConverterService
    {
        string ToWebURL(string link);

        string ToDeeplink(string link);
    }
}