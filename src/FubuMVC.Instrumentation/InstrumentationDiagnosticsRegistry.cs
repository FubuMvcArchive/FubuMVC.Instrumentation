﻿using FubuMVC.Core;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Diagnostics.Runtime.Tracing;
using FubuMVC.Instrumentation.Diagnostics;
using FubuMVC.Instrumentation.Features;
using FubuMVC.Instrumentation.Features.Instrumentation;
using FubuMVC.Instrumentation.Navigation;
using FubuMVC.Spark;

namespace FubuMVC.Instrumentation
{
    public class InstrumentationDiagnosticsRegistry : FubuRegistry
    {
        public InstrumentationDiagnosticsRegistry()
        {
            Applies
                .ToThisAssembly();

            Import<HandlerConvention>(r =>r.MarkerType<InstrumentationHandlers>());

            Views
                .TryToAttachWithDefaultConventions();

            Navigation<InstrumentationMenu>();

            Services(x =>
            {
                x.SetServiceIfNone<IInstrumentationReportCache, InstrumentationReportCache>();
                //x.SetServiceIfNone<IGridRowProvider<InstrumentationCacheModel, RouteInstrumentationModel>, InstrumentationCacheRowProvider>();
            });

            Import<SparkEngine>();
        }
    }
}