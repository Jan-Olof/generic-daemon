﻿using System;
using Functional.Common.DataTypes;

namespace Functional.Core.Commands
{
    public record AddThing : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddThing" /> class.
        /// </summary>
        private AddThing(Guid id, Timestamp created, Text name) : base(id, created) =>
            Name = name;

        public Text Name { get; }

        public static readonly Func<Guid, Timestamp, Text, Command> Create
            = (guid, timestamp, text) => new AddThing(guid, timestamp, text);
    }
}