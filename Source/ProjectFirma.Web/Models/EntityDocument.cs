﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    //TODO: 8/9/2019 TK - may rename this class EntityAttachment once the attachment work is complete and Documents are ripped out
    public class EntityDocument
    {
        private readonly string _deleteUrl;
        private readonly string _editUrl;
        private string _displayCssClass;

        public string GetDeleteUrl()
        {
            return _deleteUrl;
        }

        public string GetEditUrl()
        {
            return _editUrl;
        }

        public FileResource FileResource { get; set; }

        public void SetDisplayCssClass(string value)
        {
            _displayCssClass = value;
        }

        public string GetDisplayCssClass()
        {
            return _displayCssClass;
        }

        public string DisplayName { get; set; }
        public string Description { get; set; }

        public EntityDocument(string deleteUrl, string editUrl, FileResource fileResource, string displayCssClass,
            string displayName, string description)
        {
            _deleteUrl = deleteUrl;
            _editUrl = editUrl;
            FileResource = fileResource;
            SetDisplayCssClass(displayCssClass);
            DisplayName = displayName;
            Description = description;
        }

        public static List<EntityDocument> CreateFromEntityDocument(IEnumerable<ProjectDocument> entityDocuments)
        {
            return entityDocuments.Select(x => new EntityDocument(x.GetDeleteUrl(), x.GetEditUrl(), x.FileResource, null, x.DisplayName, x.Description)).ToList();
        }
        public static List<EntityDocument> CreateFromEntityDocument(IEnumerable<ProjectDocumentUpdate> entityDocuments)
        {
            return entityDocuments.Select(x => new EntityDocument(x.GetDeleteUrl(), x.GetEditUrl(), x.FileResource, null, x.DisplayName, x.Description)).ToList();
        }


        public static List<EntityDocument> CreateFromEntityDocument(IEnumerable<ProjectAttachment> entityDocuments)
        {
            return entityDocuments.Select(x => new EntityDocument(x.GetDeleteUrl(), x.GetEditUrl(), x.Attachment, null, x.DisplayName, x.Description)).ToList();
        }
        public static List<EntityDocument> CreateFromEntityDocument(IEnumerable<ProjectAttachmentUpdate> entityDocuments)
        {
            return entityDocuments.Select(x => new EntityDocument(x.GetDeleteUrl(), x.GetEditUrl(), x.Attachment, null, x.DisplayName, x.Description)).ToList();
        }

    }
}