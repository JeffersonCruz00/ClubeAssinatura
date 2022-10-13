using AutoMapper;
using ClubeAss.Domain;
using ClubeAss.Domain.Commands;
using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Domain.Repository.IBase;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClubeAss.Application.CommandHandlers
{
    public class CustomerHandler : IRequestHandler<CustomerAddRequest, BaseResponse>,
                                   IRequestHandler<CustomerListRequest, IEnumerable<CustomerResponse>>,
                                   IRequestHandler<CustomerGetRequest, CustomerResponse>,
                                   IRequestHandler<CustomerDeleteRequest, BaseResponse>,
                                   IRequestHandler<CustomerUpdateRequest, BaseResponse>


    {
        private readonly ICustomerRepository _clienteRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerHandler> _log;
        private readonly IMapper _mapper;

        public CustomerHandler(ICustomerRepository clienteRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerHandler> log)
        {
            _clienteRepositorio = clienteRepositorio;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = log;
        }

        public async Task<BaseResponse> Handle(CustomerAddRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<CustomerAddRequest, Customer>(request);

                _unitOfWork.BeginTransaction();

                await _clienteRepositorio.Add(customer);

                _unitOfWork.Commit();

                return new BaseResponse(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _log.LogError(ex, "Error add customer");
                return new BaseResponse(System.Net.HttpStatusCode.InternalServerError, "Ocorreu um erro inesperado, tente mais tarde!");
            }
        }

        public async Task<IEnumerable<CustomerResponse>> Handle(CustomerListRequest request, CancellationToken cancellationToken)
        {
            var customers = await _clienteRepositorio.GetAll();

            return _mapper.Map<IEnumerable<CustomerResponse>>(customers);
        }


        public async Task<CustomerResponse> Handle(CustomerGetRequest request, CancellationToken cancellationToken)
        {
            var customers = await _clienteRepositorio.GetByid(request.Id);

            return _mapper.Map<CustomerResponse>(customers);
        }

        public async Task<BaseResponse> Handle(CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _clienteRepositorio.Remove(request.Id);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

            return new BaseResponse(System.Net.HttpStatusCode.OK);
        }

        public async Task<BaseResponse> Handle(CustomerUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var customer = _mapper.Map<CustomerUpdateRequest, Customer>(request);

                _unitOfWork.BeginTransaction();

                await _clienteRepositorio.Alter(customer);

                _unitOfWork.Commit();

                return new BaseResponse(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _log.LogError(ex, "Error Alter customer");
                throw;
            }
        }

        //public Task<bool> Add(IEnumerable<Customer> customer)
        //{
        //    try
        //    {
        //        _unitOfWork.BeginTransaction();

        //        foreach (var item in customer)
        //        {
        //            _clienteRepositorio.Add(item);
        //        }

        //        _unitOfWork.Commit();

        //        return Task.FromResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        _unitOfWork.Rollback();
        //        _log.LogError(ex, "Error add customer");

        //        return Task.FromResult(false);
        //    }
        //}


        //public Task<bool> Alter(IEnumerable<Customer> customer)
        //{
        //    try
        //    {
        //        _unitOfWork.BeginTransaction();

        //        foreach (var item in customer)
        //        {
        //            _clienteRepositorio.Alter(item);
        //        }

        //        _unitOfWork.Commit();

        //        return Task.FromResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        _unitOfWork.Rollback();
        //        _log.LogError(ex, "Error Alter customer");

        //        return Task.FromResult(false);
        //    }
        //}

    }
}