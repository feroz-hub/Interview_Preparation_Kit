using ISP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Domain.Entities
{
   
        /// <summary>
        /// Normal car only drives. It does not fly.
        /// </summary>
        public sealed class Car : IDriveable
        {
            public string Model { get; }

            public Car(string model) => Model = model ?? throw new ArgumentNullException(nameof(model));

            public string Drive() => $"{Model} is driving on the road.";
        }
    }

