using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Configuration;
using NuGet.Packaging.Core;
using NuKeeper.Abstractions.Formats;

namespace NuKeeper.Abstractions.NuGetApi
{
    public class PackageSearchMetadata
    {
      

        public PackageSearchMetadata(
            PackageIdentity identity,
            PackageSource source,
            DateTimeOffset? published,
            Uri projectUri,
            IEnumerable<PackageDependency> dependencies)
        {
            ProjectUri = projectUri;
            Identity = identity ?? throw new ArgumentNullException(nameof(identity));
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Published = published;
            Dependencies = dependencies?.ToList() ?? new List<PackageDependency>();
        }

        public PackageIdentity Identity { get; }
        public PackageSource Source { get; }
        public DateTimeOffset? Published { get; }
        public Uri ProjectUri { get; }

        public IReadOnlyCollection<PackageDependency> Dependencies { get; }

        public override string ToString()
        {
            if (Published.HasValue)
            {
                return $"{Identity} from {Source}, published at {DateFormat.AsUtcIso8601(Published)}";
            }

            return $"{Identity} from {Source}, no published date";
        }
    }
}
