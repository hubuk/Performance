//-----------------------------------------------------------------------
// <copyright file="MeasurementContextFactory{TSeed}.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Performance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MeasurementContextFactory<TSeed>
    {
        private readonly MeasurementParameters<TSeed> parameters;

        private readonly IProgress<ProgressPercentageIncrease> progress;

        private readonly IGeneratorFactory generatorFactory;

        public MeasurementContextFactory(MeasurementParameters<TSeed> parameters, IProgress<ProgressPercentageIncrease> progress, IGeneratorFactory generatorFactory)
        {
            this.parameters = parameters;
            this.progress = progress;
            this.generatorFactory = generatorFactory;
        }

        public MeasurementContext<TSeed> Create()
        {
            return new MeasurementContext<TSeed>(this.parameters, this.generatorFactory.Create(this.parameters.Parameter), new ProgressUpdate(this.progress));
        }
    }
}
