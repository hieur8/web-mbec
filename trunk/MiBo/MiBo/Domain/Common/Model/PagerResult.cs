using System.Collections.Generic;
using System.Linq;

namespace MiBo.Domain.Common.Model
{
    public class PagerResult<T> : IList<T>
    {
        public IList<T> ResultList { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public long AllRecordCount { get; set; }
        public bool IsExistPrePage
        {
            get { return 0L < AllRecordCount && 1 < CurrentPageNumber; }
        }
        public bool IsExistNextPage
        {
            get { return 0L < AllRecordCount && (long)CurrentPageNumber < TotalPageNumber; }
        }
        public long TotalPageNumber
        {
            get
            {
                long total = AllRecordCount / (long)Limit; 
                if (0L < AllRecordCount % (long)Limit) total++;
                return total;
            }
        }
        public int CurrentPageNumber
        {
            get { return AllRecordCount != 0L ? Offset / Limit + 1 : 1; }
        }

        /// <summary>
        /// Gets the number of elements contained in the System.Collections.Generic.ICollection<T>.
        /// </summary>
        public int Count { get { return ResultList.Count; } }

        /// <summary>
        /// Gets a value indicating whether the System.Collections.Generic.ICollection<T> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return ResultList.IsReadOnly; }
        }

        public T this[int index]
        {
            get { return ResultList[index]; }
            set { ResultList[index] = value; }
        }

        public PagerResult()
        {
            Limit = 0;
            Offset = -1;
            AllRecordCount = -1L;
            ResultList = new List<T>();
        }

        public PagerResult(IList<T> list)
        {
            Limit = 0;
            Offset = -1;
            AllRecordCount = -1L;
            ResultList = list;
        }

        public bool IsEmpty()
        {
            return (ResultList == null || ResultList.Count <= 0);
        }

        public IList<T> SubList(int fromIndex, int toIndex)
        {
            return ResultList.Skip(fromIndex).Take(toIndex - fromIndex).ToList();
        }

        /// <summary>
        /// Adds an entry to the System.Collections.Generic.ICollection<T>.
        /// </summary>
        /// <param name="o">The object to add to the System.Collections.Generic.ICollection<T>.</param>
        public void Add(T o)
        {
            ResultList.Add(o);
        }

        /// <summary>
        /// Added all entries of the list to the System.Collections.Generic.ICollection<T>.
        /// </summary>
        /// <param name="c">The list to add to the System.Collections.Generic.ICollection<T>.</param>
        public void AddAll(IList<T> c)
        {
            foreach (var i in c)
            {
                Add(i);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the System.Collections.Generic.ICollection<T>.
        /// </summary>
        /// <param name="o">The object to remove from the System.Collections.Generic.ICollection<T>.</param>
        public void Remove(T o)
        {
            ResultList.Remove(o);
        }

        /// <summary>
        /// Removes the System.Collections.Generic.IList<T> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            ResultList.RemoveAt(index);
        }

        /// <summary>
        /// Removes all entries of the list to the System.Collections.Generic.ICollection<T>.
        /// </summary>
        /// <param name="c">The list to remove from the System.Collections.Generic.ICollection<T>.</param>
        public void RemoveAll(IList<T> c)
        {
            foreach (var i in c)
            {
                Remove(i);
            }
        }

        /// <summary>
        /// Removes all items from the System.Collections.Generic.ICollection<T>.
        /// </summary>
        public void Clear()
        {
            ResultList.Clear();
        }

        /// <summary>
        /// Determines whether the System.Collections.Generic.ICollection<T> contains a specific value.
        /// </summary>
        /// <param name="o">The object to locate in the System.Collections.Generic.ICollection<T>.</param>
        /// <returns>True if item is found in the System.Collections.Generic.ICollection<T>; otherwise, false</returns>
        public bool Contains(T o)
        {
            return ResultList.Contains(o);
        }

        /// <summary>
        /// Determines the index of a specific item in the System.Collections.Generic.IList<T>.
        /// </summary>
        /// <param name="o">The object to locate in the System.Collections.Generic.IList<T>.</param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public int IndexOf(T o)
        {
            return ResultList.IndexOf(o);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A System.Collections.Generic.IEnumerator<T> that can be used to iterate through
        ///     the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return ResultList.GetEnumerator();
        }

        /// <summary>
        /// Creates an array from a System.Collections.Generic.IEnumerable<T>.
        /// </summary>
        /// <returns>An array that contains the elements from the input sequence.</returns>
        public T[] ToArray()
        {
            return ResultList.ToArray();
        }

        /// <summary>
        /// Inserts an item to the System.Collections.Generic.IList<T> at the specified
        ///     index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the System.Collections.Generic.IList<T>.</param>
        public void Insert(int index, T item)
        {
            ResultList.Insert(index, item);
        }

        /// <summary>
        /// Copies the elements of the System.Collections.Generic.ICollection<T> to an
        ///     System.Array, starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements
        ///     copied from System.Collections.Generic.ICollection<T>. The System.Array must
        ///     have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            ResultList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the System.Collections.Generic.ICollection<T>.
        /// </summary>
        /// <param name="o">The object to remove from the System.Collections.Generic.ICollection<T>.</param>
        /// <returns>true if item was successfully removed from the System.Collections.Generic.ICollection<T>;
        ///     otherwise, false. This method also returns false if item is not found in
        ///    the original System.Collections.Generic.ICollection<T>.</returns>
        bool ICollection<T>.Remove(T o)
        {
            return ResultList.Remove(o);
        }

        /// <summary>
        /// Returns an enumarator that iterates through the collection
        /// </summary>
        /// <returns>A System.Collections.Generic.IEnumerator<T> that can be used to iterate through the collection</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ResultList.GetEnumerator();
        }
    }
}