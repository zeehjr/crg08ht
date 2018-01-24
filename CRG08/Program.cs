using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.View;
using FirebirdSql.Data.Services;

namespace CRG08
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int cont = 0;
            CRG08.Properties.Settings.Default.IndiceParou = -1;

            DataMigration.Migration.Exec();

            do
            {
                if (UltimosDAO.RetornaPrimeiraInicializacao())
                {
                    var bkp = new Backup();
                    bkp.ShowDialog();
                    UltimosDAO.SetarPrimeiraInicializacao(false);
                }
                VO.Backup backup = BackupDAO.RetornaBackup();
                if (backup != null)
                {
                    
                    if (Directory.Exists(backup.CaminhoBackup))
                    {
                        switch (backup.Periodo)
                        {
                            case 0:
                                if (backup.DataUltimoBackup == "")
                                {
                                    FbBackup backupSvc = new FbBackup();
                                    string NomeArquivo = backup.CaminhoBackup + "/BackUp CRG 08 - Dia " +
                                                         DateTime.Today.Day.ToString("0,0") + "_" +
                                                         DateTime.Today.Month.ToString("0,0")+".crg";
                                    if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                                    backupSvc.ConnectionString = Util.DAO.Conn;
                                    backupSvc.Verbose = true;
                                    backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                                    backupSvc.Execute();
                                    string date = DateTime.Today.ToString();
                                    BackupDAO.AlterarDataUltimoBackup(date);
                                }
                                else
                                {
                                    DateTime data = Convert.ToDateTime(backup.DataUltimoBackup);
                                    data = data.AddDays(+1);
                                    if (DateTime.Today == data || DateTime.Today > data)
                                    {
                                        FbBackup backupSvc = new FbBackup();
                                        string NomeArquivo = backup.CaminhoBackup + "/BackUp CRG 08 - Dia " +
                                                             DateTime.Today.Day.ToString("0,0") + "_" +
                                                             DateTime.Today.Month.ToString("0,0")+".crg";
                                        if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                                        backupSvc.ConnectionString = Util.DAO.Conn;
                                        backupSvc.Verbose = true;
                                        backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                                        backupSvc.Execute();
                                        string date = DateTime.Today.ToString();
                                        BackupDAO.AlterarDataUltimoBackup(date);
                                    }
                                }
                                break;
                            case 1:
                                if (backup.DataUltimoBackup == "")
                                {
                                    FbBackup backupSvc = new FbBackup();
                                    string NomeArquivo = backup.CaminhoBackup + "/BackUp CRG 08 - Dia " +
                                                         DateTime.Today.Day.ToString("0,0") + "_" +
                                                         DateTime.Today.Month.ToString("0,0")+".crg";
                                    if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                                    backupSvc.ConnectionString = Util.DAO.Conn;
                                    backupSvc.Verbose = true;
                                    backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                                    backupSvc.Execute();
                                    string date = DateTime.Today.ToString();
                                    BackupDAO.AlterarDataUltimoBackup(date);
                                }
                                else
                                {
                                    DateTime data = Convert.ToDateTime(backup.DataUltimoBackup);
                                    data = data.AddDays(+7);
                                    if (DateTime.Today == data || DateTime.Today > data)
                                    {
                                        FbBackup backupSvc = new FbBackup();
                                        string NomeArquivo = backup.CaminhoBackup + "/BackUp CRG 08 - Dia " +
                                                             DateTime.Today.Day.ToString("0,0") + "_" +
                                                             DateTime.Today.Month.ToString("0,0")+".crg";
                                        if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                                        backupSvc.ConnectionString = Util.DAO.Conn;
                                        backupSvc.Verbose = true;
                                        backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                                        backupSvc.Execute();
                                        string date = DateTime.Today.ToString();
                                        BackupDAO.AlterarDataUltimoBackup(date);
                                    }
                                }
                                break;
                            case 2:
                                if (backup.DataUltimoBackup == "")
                                {
                                    FbBackup backupSvc = new FbBackup();
                                    string NomeArquivo = backup.CaminhoBackup + "/BackUp CRG 08 - Dia " +
                                                         DateTime.Today.Day.ToString("0,0") + "_" +
                                                         DateTime.Today.Month.ToString("0,0")+".crg";
                                    if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                                    backupSvc.ConnectionString = Util.DAO.Conn;
                                    backupSvc.Verbose = true;
                                    backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                                    backupSvc.Execute();
                                    string date = DateTime.Today.ToString();
                                    BackupDAO.AlterarDataUltimoBackup(date);
                                }
                                else
                                {
                                    DateTime data = Convert.ToDateTime(backup.DataUltimoBackup);
                                    data = data.AddDays(+30);
                                    if (DateTime.Today == data || DateTime.Today > data)
                                    {
                                        FbBackup backupSvc = new FbBackup();
                                        string NomeArquivo = backup.CaminhoBackup + "/BackUp CRG 08 - Dia " +
                                                             DateTime.Today.Day.ToString("0,0") + "_" +
                                                             DateTime.Today.Month.ToString("0,0")+".crg";
                                        if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                                        backupSvc.ConnectionString = Util.DAO.Conn;
                                        backupSvc.Verbose = true;
                                        backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                                        backupSvc.Execute();
                                        string date = DateTime.Today.ToString();
                                        BackupDAO.AlterarDataUltimoBackup(date);
                                    }
                                }
                                break;
                        }
                        Application.Run(new Principal());
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                            "O caminho para o backup automático não está disponivel, deseja continuar?",
                            "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Application.Run(new Principal());
                        }
                        else Properties.Settings.Default.FecharPrograma = true;
                    }
                }
                else
                {
                    Application.Run(new Principal());
                }
            } while (Properties.Settings.Default.FecharPrograma == false);

            Environment.Exit(0);
        }
    }
}
