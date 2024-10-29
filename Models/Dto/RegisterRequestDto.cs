namespace InfoGem.Dto;
public record struct RegisterRequestDto(string Email, string Password, string UserName, string PhoneNumber, string? CPF, string? CNPJ, bool IsVendor, DateOnly BirthDate);