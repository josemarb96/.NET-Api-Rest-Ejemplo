using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using DAL.Manejadora;
using BL.Manejadora;

namespace BL.Manejadora
{
    public class clsManejadora_BL
    {
        /// <summary>
        /// Insertar una persona
        /// </summary>
        /// <param name="miPersona"></param>
        /// <returns></returns>
        public int insertarPersonaBL (clsPersona miPersona)
        {
            int i = new clsManejadora_DAL().insertarPersonaDAL(miPersona);
            return i;
        }

        /// <summary>
        /// Borrar a una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deletePersonaBL(int id)
        {
            clsManejadora_DAL miManejadora = new clsManejadora_DAL();
            return miManejadora.borrarPersonaDAL(id);
        }

        /// <summary>
        /// Actualizar a una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int updatePersonaBL(clsPersona persona)
        {
            clsManejadora_DAL miManejadora = new clsManejadora_DAL();
            return miManejadora.actualizarPersonaDAL(persona);
        }

        /// <summary>
        /// Ver persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona selectPersonaBL(int id)
        {
            clsManejadora_DAL miManejadora = new clsManejadora_DAL();
            return miManejadora.verPersonaDAL(id);
        }

    } //Fin class
}
