﻿using System.IO;
using XCommon.ProjectGerator.Application.Commands;

namespace XCommon.ProjectGerator.Application.CSharp.Writter
{
    public class CreateFile : Command<CreateFileParam>
    {
        public CreateFile(CreateFileParam param)
            : base(param)
        {
        }

        protected override void Run(CreateFileParam param)
        {
            if (!Directory.Exists(param.Path))
                Directory.CreateDirectory(param.Path);

            var file = Path.Combine(param.Path, param.FileName);

            File.WriteAllText(file, param.Template);
        }
    }
}