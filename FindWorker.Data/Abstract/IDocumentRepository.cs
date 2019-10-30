using FindWorker.Data.Abstract;
using FindWorker.Entity.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Document = FindWorker.Entity.Models.Document;

namespace FindWorker.Data.Abstract
{
    public interface IDocumentRepository: IGenericRepository<Document>
    {
    }
}
