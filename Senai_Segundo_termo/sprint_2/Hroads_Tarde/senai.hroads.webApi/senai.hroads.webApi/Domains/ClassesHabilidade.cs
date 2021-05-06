using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class ClassesHabilidade
    {
        public int? IdClasses { get; set; }
        public int? IdHabilidades { get; set; }

        public virtual Class IdClassesNavigation { get; set; }
        public virtual Habilidade IdHabilidadesNavigation { get; set; }
    }
}
