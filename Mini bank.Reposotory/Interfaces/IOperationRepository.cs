using Mini_bank.Reposotory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Interfaces
{
    public interface IOperationRepository
    {
        //Operation GetSingleOperation(int operationId);
        //List<Operation> GetOperationsOfAccount(int accountId);
        //int AddOperation(Operation newOperation);
        //    List<Operation> LoadOperations();
        //void SaveOperations(List<Operation> operationsToSave);
        public int AddOperation(Operation newOperation);
        List<Operation> GetOperationsOfAccount(int accountId);
        Operation GetSingleOperation(int operationId);

        public List<Operation> LoadOperations();
        public void SaveOperations(List<Operation> operationsToSave);


    }
}
