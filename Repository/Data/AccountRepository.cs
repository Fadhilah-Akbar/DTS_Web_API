using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using DTS_Web_Api.ViewModels;

namespace DTS_Web_Api.Repository.Data
{
    public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProfilingRepository _profilingRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        public AccountRepository(MyContext context,
        IUniversityRepository universityRepository,
        IEducationRepository educationRepository,
        IEmployeeRepository employeeRepository,
        IProfilingRepository profilingRepository,
        IAccountRoleRepository accountRoleRepository) : base(context)
        {
            _universityRepository = universityRepository;
            _educationRepository = educationRepository;
            _employeeRepository = employeeRepository;
            _profilingRepository = profilingRepository;
            _accountRoleRepository = accountRoleRepository;
        }

        public async Task RegisterAsync(RegisterVM registerVM)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {

                var university = new University
                {
                    Name = registerVM.UniversityName
                };
                if (await _universityRepository.IsNameExist(registerVM.UniversityName))
                {

                }
                else
                {
                    await _universityRepository.InsertAsync(university);
                }

                var education = new Education
                {
                    Major = registerVM.Major,
                    Degree = registerVM.Degree,
                    Gpa = registerVM.GPA,
                    UniversityId = university.Id,
                };
                await _educationRepository.InsertAsync(education);

                // Employee
                var employee = new Employee
                {
                    Nik = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    BirthDate = registerVM.BirthDate,
                    Gender = registerVM.Gender,
                    PhoneNumber =registerVM.PhoneNumber,
                    Email = registerVM.Email,
                    HiringDate = DateTime.Now,
                };
                await _employeeRepository.InsertAsync(employee);
                // Account
                var account = new Account
                {
                    Nik = registerVM.NIK,
                    Password = registerVM.Password,
                };
                await InsertAsync(account);
                // Profiling
                var profiling = new Profiling
                {
                    Id = registerVM.NIK,
                    EducationId = education.Id,
                };
                await _profilingRepository.InsertAsync(profiling);
                // AccountRole
                var accountRole = new AccountRole
                {
                    RoleId = 1,
                    EmployeeNik = registerVM.NIK,
                };
                await _accountRoleRepository.InsertAsync(accountRole);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public async Task<bool> LoginAsync(LoginVM loginVM)
        {
            var getEmployees = await _employeeRepository.GetAllAsync();
            var getAccounts = await GetAllAsync();

            var getUserData = getEmployees.Join(getAccounts,
                                                e => e.Nik,
                                                a => a.Nik,
                                                (e, a) => new LoginVM
                                                {
                                                    Email = e.Email,
                                                    Password = a.Password
                                                })
                                          .FirstOrDefault(ud => ud.Email == loginVM.Email);

            return getUserData is not null && loginVM.Password == getUserData.Password;
        }
    }
}
