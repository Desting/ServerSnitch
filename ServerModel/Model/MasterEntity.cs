﻿using DataExtractor.Model.IIS;
using ServerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model
{
    public class MasterEntity
    {
        public EnvironmentData environment { get; set; }
        public IISStringContainer iis { get; set; }
        public List<ServiceData> services { get; set; }
        
        public string Id { get; set; }

        //New
        public string SLA { get; set; }
        public int cost { get; set; }

        [Key, ForeignKey("owner")]
        public string ownerId { get; set; }
        public virtual Owner owner { get; set; }

        public virtual List<Tag> tags { get; set; }

        public MasterEntity()
        {
        }

        public MasterEntity(EnvironmentData environment, IISStringContainer iis, List<ServiceData> services)
        {
            this.environment = environment;
            this.iis = iis;
            this.services = services;

        }

    }
}
