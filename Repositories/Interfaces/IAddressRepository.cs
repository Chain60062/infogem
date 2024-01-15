using InfoGem.Models;

public interface IAddressRepository
{
    public Task<IQueryable<Address>?> GetUserAddresses(Guid userId);

    public Task<Address?> CreateNewAddress(Address address);

    public Task<Address?> UpdateAddressById(long addressToBeUpdatedId, Address address);

    public Task<bool?> RemoveAddress(long addressId);
}