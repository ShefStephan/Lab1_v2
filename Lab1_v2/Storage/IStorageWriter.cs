namespace Lab1_v2.Storage;

public interface IStorageWriter
{
    public Task SaveCommandAsync(string command);
    public Task ClearFileAsync();
}