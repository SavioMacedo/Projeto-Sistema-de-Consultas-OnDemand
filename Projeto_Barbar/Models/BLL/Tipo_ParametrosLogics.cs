using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Projeto_Barbar.Models.BLL
{
    public class Tipo_ParametrosLogics:IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public Tipo_ParametrosLogics(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Tipo_Parametro> PuxarTodos()
        {
            return new List<Tipo_Parametro>(_unitOfWork.GetRepository<Tipo_Parametro>().GetPagedList().Items).ToList();
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
