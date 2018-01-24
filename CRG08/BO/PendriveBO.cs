using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CRG08.BO
{
    public class ItemPendrive
    {
        public string Unidade { get; set; }
        public List<string> Arquivos { get; set; }
    }

    public static class PendriveBO
    {
        public static List<ItemPendrive> RetornaPendrivePorCrgETrat(int crg, int numTrat)
        {
            var drives = DriveInfo.GetDrives().Where(x => x.IsReady && x.DriveType == DriveType.Removable);
            if (!drives.Any())
            {
                return null;
            }
            var retorno = new List<ItemPendrive>();
            foreach (var drive in drives)
            {
                var dir = drive.Name + "CRG" + crg.ToString("00");
                if (!Directory.Exists(dir)) continue;
                var arquivos = Directory.GetFiles(dir, "SEC" + numTrat.ToString("000") + ".TRT", SearchOption.AllDirectories).ToList();
                retorno.Add(new ItemPendrive
                {
                    Unidade = drive.Name,
                    Arquivos = arquivos
                });
            }

            return retorno.Any() ? retorno : null;
        }

        public static List<ItemPendrive> RetornaPendrivesPorCRG(int crg)
        {
            var drives = DriveInfo.GetDrives().Where(x => x.IsReady && x.DriveType == DriveType.Removable);
            if (!drives.Any())
            {
                return null;
            }
            var retorno = new List<ItemPendrive>();
            foreach (var drive in drives)
            {
                var dir = drive.Name + "CRG" + crg.ToString("00");
                if (!Directory.Exists(dir)) continue;
                var arquivos = Directory.GetFiles(dir).ToList();
                retorno.Add(new ItemPendrive
                {
                    Unidade = drive.Name,
                    Arquivos = arquivos
                });
            }

            return retorno.Any() ? retorno : null;
        }
    }
}
