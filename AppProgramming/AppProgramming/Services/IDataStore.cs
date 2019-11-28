using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppProgramming.Models;

namespace AppProgramming.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<Item> GetItemAsync(string id);
        Task<bool> MarkAsCompletedAsync(string Id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
