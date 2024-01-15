using InfoGem.Data;
using InfoGem.Models;

public class EFAddressRepository : IAddressRepository
{
    private readonly AppDbContext _db;

    public EFAddressRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Address?> CreateNewAddress(Address address)
    {
        await _db.Addresses.AddAsync(address);
        await _db.SaveChangesAsync();

        return address;
    }

    public async Task<IQueryable<Address>?> GetUserAddresses(Guid userId)
    {
        var user = await _db.Users.FindAsync(userId);
        // var user = await _userManager.FindByIdAsync(userId.ToString()):

        if (user is null) return null;

        var images = user.Addresses.AsQueryable();

        return images;
    }

    public async Task<bool?> RemoveAddress(long addressId)
    {
        var addr = await _db.Addresses.FindAsync(addressId);
        if (addr is null) return false;

        _db.Remove(addr);

        var result = await _db.SaveChangesAsync();

        return result > 0 ? true : false;
    }

    public async Task<Address?> UpdateAddressById(long addressToBeUpdatedId, Address address)
    {
        var updatedAddr = await _db.Addresses.FindAsync(addressToBeUpdatedId);

        if (updatedAddr is not null)
        {
            updatedAddr.Cep = address.Cep;
            updatedAddr.City = address.City;
            updatedAddr.Street = address.Street;
            updatedAddr.Complement = address.Complement;
            updatedAddr.Neighborhood = address.Neighborhood;
            updatedAddr.StateCode = address.StateCode;
            updatedAddr.HouseNumber = address.HouseNumber;

            _db.Update(updatedAddr);
            await _db.SaveChangesAsync();
        }
        return updatedAddr;
    }
}