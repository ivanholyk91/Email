using Akavache;
using ParkingPass.Student.Infrastructure.DAL.Interfaces;
using ParkingPass.Student.Infrastructure.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPass.Student.Infrastructure.DAL
{
    public class DataService<T> : IDataService<T>
    {
        public DataService(DataTypeKey typeKey, BlobCacheType blobType)
        {
            _key = typeKey.ToString();
            _blobType = blobType;
        }
        public bool Save(T obj)
        {
            try
            {
                Unit result = new Unit();
                switch (_blobType)
                {
                    case BlobCacheType.LocalMachine:
                        result = BlobCache.LocalMachine.InsertObject(_key, obj).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.Secure:
                        result = BlobCache.Secure.InsertObject(_key, obj).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.UserAccount:
                        result = BlobCache.UserAccount.InsertObject(_key, obj).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.InMemory:
                        result = BlobCache.InMemory.InsertObject(_key, obj).GetAwaiter().GetResult();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public T Get()
        {
            try
            {
                var result = default(T);
                switch (_blobType)
                {
                    case BlobCacheType.LocalMachine:
                        result = BlobCache.LocalMachine.GetObject<T>(_key).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.Secure:
                        result = BlobCache.Secure.GetObject<T>(_key).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.UserAccount:
                        result = BlobCache.UserAccount.GetObject<T>(_key).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.InMemory:
                        result = BlobCache.InMemory.GetObject<T>(_key).GetAwaiter().GetResult();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return result;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public bool Remove()
        {
            try
            {
                Unit result = new Unit();
                switch (_blobType)
                {
                    case BlobCacheType.LocalMachine:
                        result = BlobCache.LocalMachine.Invalidate(_key).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.Secure:
                        result = BlobCache.Secure.Invalidate(_key).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.UserAccount:
                        result = BlobCache.UserAccount.Invalidate(_key).GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.InMemory:
                        result = BlobCache.InMemory.Invalidate(_key).GetAwaiter().GetResult();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(T obj)
        {
            this.Remove();
            var result = this.Save(obj);
            return result;
        }

        public bool Exist()
        {
            try
            {
                IEnumerable<string> result;
                switch (_blobType)
                {
                    case BlobCacheType.LocalMachine:
                        result = BlobCache.LocalMachine.GetAllKeys().GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.Secure:
                        result = BlobCache.Secure.GetAllKeys().GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.UserAccount:
                        result = BlobCache.UserAccount.GetAllKeys().GetAwaiter().GetResult();
                        break;
                    case BlobCacheType.InMemory:
                        result = BlobCache.InMemory.GetAllKeys().GetAwaiter().GetResult();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return result.Any(q => q == _key);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string _key = "token";
        private BlobCacheType _blobType;
    }
}

