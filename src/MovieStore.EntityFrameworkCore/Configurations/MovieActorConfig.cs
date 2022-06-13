//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using MovieStore.MoviesActors;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MovieStore.Configurations
//{
//    public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
//    {
//        public void Configure(EntityTypeBuilder<MovieActor> b)
//        {

//            b.ToTable(MovieStoreConsts.DbTablePrefix + "MovieActors", MovieStoreConsts.DbSchema);
//            b.HasKey(bc => new { bc.MovieId, bc.ActorId });

//        }
//    }
//}
