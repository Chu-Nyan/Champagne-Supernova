using System;

namespace ChampagneSupernova.Library.Algorithm
{
    public static class MergeSort<T> where T : IComparable<T>
    {
        private static T[] _tempArr;

        public static void Start(T[] arr)
        {
            int length = arr.Length;
            _tempArr = new T[length];
            Split(arr, 0, length - 1);
        }

        private static void Split(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (right + left) / 2;

                Split(arr, left, mid);
                Split(arr, mid + 1, right);
                Merge(arr, left, mid + 1, right);
            }
        }

        private static void Merge(T[] arr, int left, int mid, int right)
        {
            int l = left;
            int m = mid;
            int r = right;
            int index = l;

            while (index <= r)
            {
                if (m > right || l < mid
                 && arr[l].CompareTo(arr[m]) <= 0)
                    _tempArr[index++] = arr[l++];
                else
                    _tempArr[index++] = arr[m++];
            }

            for (int i = left; i <= right; i++)
            {
                arr[i] = _tempArr[i];
            }
        }
    }
}
