using Aplicacion.Servicios.interfaces;
using Dominio.Dto;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios.impl
{
    public class TransformToDirectoryImpl : ITransformToDirectory
    {

        public List<TdDirectoryDto> transformToDto(List<TdDocumento> documentos)
        {
            List<TdDirectoryDto> list = new List<TdDirectoryDto>();
            TdDirectoryDto directorios = new TdDirectoryDto();
            directorios.children = new List<TdDirectoryDto>();
            directorios.id = 1;

            foreach (TdDocumento d in documentos)
            {
                directorios = addPath(directorios, Path.Combine(d.Ruta, d.Nombre).Split(Path.DirectorySeparatorChar), d.Id);
            }
            list.Add(directorios);
            return list;
        }

        private TdDirectoryDto addPath(TdDirectoryDto directorios, string[] paths, int nextId)
        {
            TdDirectoryDto nodo = new TdDirectoryDto();
            TdDirectoryDto nodoAux = new TdDirectoryDto();
            if (paths.Length > 0)
            {


                nodo.id = -1;
                nodo.title = paths[0];
                if (paths.Length == 1)
                {
                    nodo.file = paths[0].Split(".")[1];
                    nodo.id = nextId;
                }

                if (paths.Length > 1)
                {
                    nodo.children = new List<TdDirectoryDto>();


                    TdDirectoryDto nuevo = new TdDirectoryDto();
                    if (paths[0].Equals(directorios.title))
                    {
                        nodo = directorios;
                        if (directorios.children.Count > 0)
                        {
                            nodoAux.id = directorios.children[0].id;
                            nodoAux.children = new List<TdDirectoryDto>();

                            for (int i = 0; i < directorios.children.Count; i++)
                            {
                                if (directorios.children[i].title.Equals(paths[1]))
                                {
                                    nodoAux = directorios.children[i];
                                    break;
                                }
                            }
                        }

                    }
                    if (nodoAux.title == null)
                        nodo.children.Add(addPath(nodoAux, paths.Skip(1).ToArray(), nextId));
                    else
                    {

                        nodo.children = new List<TdDirectoryDto>();
                        nodo.children.Add(addPath(nodoAux, paths.Skip(1).ToArray(), nextId));
                    }



                }
            }

            return nodo;
        }
    }
}