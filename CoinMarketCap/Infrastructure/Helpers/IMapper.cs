namespace CoinMarketCap.Infrastructure.Helpers
{
    public interface IMapper<T1, T2>
    {
        T2 Map(T1 input);
    }

    public interface IAsyncMapper<T1, T2>
    {
        Task<T2> MapAsync(T1 input);
    }
}
