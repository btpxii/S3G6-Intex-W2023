using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models
{
    public interface IIntex2Repository
    {
        // Add IQueryables here to access tables/models. Change get to get; set; if we need to allow change to the database (i think)
        IQueryable<Analysis> Analyses { get; }
        IQueryable<AnalysisTextile> AnalysisTextiles { get; }
        IQueryable<Artifactfagelgamousregister> Artifactfagelgamousregisters { get; }
        IQueryable<ArtifactfagelgamousregisterBurialmain> ArtifactfagelgamousregisterBurialmains { get; }
        IQueryable<Artifactkomaushimregister> Artifactkomaushimregisters { get; }
        IQueryable<ArtifactkomaushimregisterBurialmain> ArtifactkomaushimregisterBurialmains { get; }
        IQueryable<Biological> Biologicals { get; }
        IQueryable<BiologicalC14> BiologicalC14s { get; }
        IQueryable<Bodyanalysischart> Bodyanalysischarts { get; }
        IQueryable<Book> Books { get; }
        IQueryable<Burialmain> Burialmains { get; }
        IQueryable<BurialmainBiological> BurialmainBiologicals { get; }
        IQueryable<BurialmainBodyanalysischart> BurialmainBodyanalysischarts { get; }
        IQueryable<BurialmainCranium> BurialmainCrania { get; }
        IQueryable<BurialmainTextile> BurialmainTextiles { get; }
        IQueryable<C14> C14s { get; }
        IQueryable<Color> Colors { get; }
        IQueryable<ColorTextile> ColorTextiles { get; }
        IQueryable<Completebodyanalysischart> Completebodyanalysischarts { get; }
        IQueryable<Cranium> Crania { get; }
        IQueryable<Decoration> Decorations { get; }
        IQueryable<DecorationTextile> DecorationTextiles { get; }
        IQueryable<Dimension> Dimensions { get; }
        IQueryable<DimensionTextile> DimensionTextiles { get; }
        IQueryable<Newsarticle> Newsarticles { get; }
        IQueryable<PhotodataTextile> PhotodataTextiles { get; }
        IQueryable<Photodatum> Photodata { get; }
        IQueryable<Photoform> Photoforms { get; }
        IQueryable<Structure> Structures { get; }
        IQueryable<StructureTextile> StructureTextiles { get; }
        IQueryable<Teammember> Teammembers { get; }
        IQueryable<Textile> Textiles { get; }
        IQueryable<Textilefunction> Textilefunctions { get; }
        IQueryable<TextilefunctionTextile> TextilefunctionTextiles { get; }
        IQueryable<Yarnmanipulation> Yarnmanipulations { get; }
        IQueryable<YarnmanipulationTextile> YarnmanipulationTextiles { get; }
    }
}
