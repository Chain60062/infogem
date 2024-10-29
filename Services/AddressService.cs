using InfoGem.Dto;
using InfoGem.Models;
using InfoGem.Repositories;
namespace InfoGem.Services;

public class AddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<IQueryable<Address>?> GetUserAddresses(Guid userId)
        => await _addressRepository.GetUserAddresses(userId);


    public async Task<Address?> CreateNewAddress(AddressDto addressDto)

    {
        Address address = new Address()
        {
            Cep = addressDto.Cep,
            City = addressDto.City,
            Street = addressDto.Street,
            Complement = addressDto.Complement,
            Neighborhood = addressDto.Neighborhood,
            StateCode = addressDto.StateCode,
            HouseNumber = addressDto.HouseNumber
        };
        return await _addressRepository.CreateNewAddress(address);
    }

    public async Task<Address?> UpdateAddressById(long addressToBeUpdatedId, AddressDto addressDto)
    {
        Address address = new Address()
        {
            Cep = addressDto.Cep,
            City = addressDto.City,
            Street = addressDto.Street,
            Complement = addressDto.Complement,
            Neighborhood = addressDto.Neighborhood,
            StateCode = addressDto.StateCode,
            HouseNumber = addressDto.HouseNumber
        };
        return await _addressRepository.UpdateAddressById(addressToBeUpdatedId, address);
    }

    public async Task<bool?> RemoveAddress(long addressId) => await _addressRepository.RemoveAddress(addressId);
}