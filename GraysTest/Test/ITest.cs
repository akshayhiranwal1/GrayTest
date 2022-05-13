using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraysInt
{
    public interface ITests
    {
        /// <summary>
        /// Remove matching items from the collection without using linq. Input should remain unchanged.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        IEnumerable<T> RemoveItemsInNewCollection<T>(IEnumerable<T> collection, T item);

        /// <summary>
        /// Remove matching items from the collection using only IList interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        void RemoveItemsFromCollection<T>(IList<T> collection, T item);

        /// <summary>
        /// Returns a new list where the items are in the reverse order without using linq
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        IEnumerable<T> ReverseCollectionOrder<T>(IList<T> collection);

        /// <summary>
        /// Yield the incrementing powers of the provided input. e.g. input of 2 returns 2,4,8,16
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        IEnumerable<int> YieldPowersOf(int power);

        /// <summary>
        /// Remove characters from the string that aren't alphanumeric (A-Z, 0-9 and hyphen)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string RemoveNonAlphanumeric(string input);

        /// <summary>
        /// Get the contents of a webpage as a string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<string> DownloadFileAsync(string url);

        /// <summary>
        /// Assume TSQL with the following table
        /// 
        /// CREATE TABLE Persons (
        ///     PersonID int NOT NULL,
        ///     LastName varchar(255),
        ///     FirstName varchar(255),
        ///     Address varchar(255),
        ///     City varchar(255),
        ///     PRIMARY KEY (PersonID)
        ///);
        /// </summary>
        /// <returns></returns>
        Task DeletePeopleWithLastNameAsync(string connectionString, string lastName);

        /// <summary>
        /// Assume TSQL with the following table
        /// 
        /// CREATE TABLE Persons (
        ///     PersonID int NOT NULL,
        ///     LastName varchar(255),
        ///     FirstName varchar(255),
        ///     Address varchar(255),
        ///     City varchar(255),
        ///     PRIMARY KEY (PersonID)
        ///);
        /// </summary>
        /// <returns>Key is City, Value is Count</returns>
        Task<Dictionary<string, int>> GetCountOfPeopleInEachCityAsync(string connectionString);

        /// <summary>
        /// Assume TSQL with the following table
        /// 
        /// CREATE TABLE Persons (
        ///     PersonID int NOT NULL,
        ///     LastName varchar(255),
        ///     FirstName varchar(255),
        ///     Address varchar(255),
        ///     City varchar(255),
        ///     PRIMARY KEY (PersonID)
        ///);
        /// </summary>
        /// <returns></returns>
        Task InsertPersonAsync(string connectionString, string lastName, string firstName, string address, string city);

        /// <summary>
        /// Adds together all strings that are numbers and returns the result. e.g. "hi", "2", "two", "10 p", "5.3" = 7.3
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        decimal AddStringIfNumber(IEnumerable<string> input);
    }
}
