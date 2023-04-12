using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models
{
    public class EFIntex2Repository : IIntex2Repository
    {
        private MummiesDbContext context { get; set; }

        public EFIntex2Repository(MummiesDbContext x)
        {
            context = x;
        }

        public IQueryable<Burialmain> Burialmains => context.Burialmains;

        public IQueryable<Analysis> Analyses => context.Analyses;

        public IQueryable<AnalysisTextile> AnalysisTextiles => context.AnalysisTextiles;

        public IQueryable<Artifactfagelgamousregister> Artifactfagelgamousregisters => context.Artifactfagelgamousregisters;

        public IQueryable<ArtifactfagelgamousregisterBurialmain> ArtifactfagelgamousregisterBurialmains => context.ArtifactfagelgamousregisterBurialmains;

        public IQueryable<Artifactkomaushimregister> Artifactkomaushimregisters => context.Artifactkomaushimregisters;

        public IQueryable<ArtifactkomaushimregisterBurialmain> ArtifactkomaushimregisterBurialmains => context.ArtifactkomaushimregisterBurialmains;

        public IQueryable<Biological> Biologicals => context.Biologicals;

        public IQueryable<BiologicalC14> BiologicalC14s => context.BiologicalC14s;

        public IQueryable<Bodyanalysischart> Bodyanalysischarts => context.Bodyanalysischarts;

        public IQueryable<Book> Books => context.Books;

        public IQueryable<BurialmainBiological> BurialmainBiologicals => context.BurialmainBiologicals;

        public IQueryable<BurialmainBodyanalysischart> BurialmainBodyanalysischarts => context.BurialmainBodyanalysischarts;

        public IQueryable<BurialmainCranium> BurialmainCrania => context.BurialmainCrania;

        public IQueryable<BurialmainTextile> BurialmainTextiles => context.BurialmainTextiles;

        public IQueryable<C14> C14s => context.C14s;

        public IQueryable<Color> Colors => context.Colors;

        public IQueryable<ColorTextile> ColorTextiles => context.ColorTextiles;

        public IQueryable<Completebodyanalysischart> Completebodyanalysischarts => context.Completebodyanalysischarts;

        public IQueryable<Cranium> Crania => context.Crania;

        public IQueryable<Decoration> Decorations => context.Decorations;

        public IQueryable<DecorationTextile> DecorationTextiles => context.DecorationTextiles;

        public IQueryable<Dimension> Dimensions => context.Dimensions;

        public IQueryable<DimensionTextile> DimensionTextiles => context.DimensionTextiles;

        public IQueryable<Newsarticle> Newsarticles => context.Newsarticles;

        public IQueryable<PhotodataTextile> PhotodataTextiles => context.PhotodataTextiles;

        public IQueryable<Photodatum> Photodata => context.Photodata;

        public IQueryable<Photoform> Photoforms => context.Photoforms;

        public IQueryable<Structure> Structures => context.Structures;

        public IQueryable<StructureTextile> StructureTextiles => context.StructureTextiles;

        public IQueryable<Teammember> Teammembers => context.Teammembers;

        public IQueryable<Textile> Textiles => context.Textiles;

        public IQueryable<Textilefunction> Textilefunctions => context.Textilefunctions;

        public IQueryable<TextilefunctionTextile> TextilefunctionTextiles => context.TextilefunctionTextiles;

        public IQueryable<Yarnmanipulation> Yarnmanipulations => context.Yarnmanipulations;

        public IQueryable<YarnmanipulationTextile> YarnmanipulationTextiles => context.YarnmanipulationTextiles;
    }
}

