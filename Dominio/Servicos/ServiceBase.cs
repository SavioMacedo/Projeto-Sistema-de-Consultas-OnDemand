using AutoMapper;
using Dominio.Interfaces;
using Dominio.Interfaces.Servicos;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Dominio.Servicos
{
    public class ServiceBase : IServiceBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();

            disposed = true;
        }
    }
}
