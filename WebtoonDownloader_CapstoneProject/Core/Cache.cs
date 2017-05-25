using System.IO;
using System.Text;
using System.Xml.Serialization;
using WebtoonDownloader_CapstoneProject.UI.Forms;

namespace WebtoonDownloader_CapstoneProject.Core
{
	static class Cache
	{
		static Cache( )
		{
			if ( !Directory.Exists( GlobalVar.CACHE_DIRECTORY ) )
				Directory.CreateDirectory( GlobalVar.CACHE_DIRECTORY );
		}

		public enum CacheType
		{
			WebtoonSection
		}

		public static void Register( CacheType type, string id, object data )
		{
			switch ( type )
			{
				case CacheType.WebtoonSection:
					XmlSerializer xmlSerializer = new XmlSerializer( typeof( WebtoonSectionCacheStruct ) );
					using ( StreamWriter wr = new StreamWriter( GlobalVar.CACHE_DIRECTORY + "\\cache__" + id + ".dat" ) )
					{
						xmlSerializer.Serialize( wr, ( WebtoonSectionCacheStruct ) data );
					}

					break;
				default:
					using ( FileStream stream = new FileStream( GlobalVar.CACHE_DIRECTORY + "\\cache__" + id + ".dat", FileMode.Create ) )
					{
						using ( StreamWriter streamWriter = new StreamWriter( stream, Encoding.UTF8 ) )
						{
							streamWriter.Write( data );
							streamWriter.Flush( );
						}
					}

					break;
			}
		}

		public static T Get<T>( CacheType type, string id )
		{
			switch ( type )
			{
				case CacheType.WebtoonSection:
					if ( File.Exists( GlobalVar.CACHE_DIRECTORY + "\\cache__" + id + ".dat" ) )
					{
						XmlSerializer xmlSerializer = new XmlSerializer( typeof( WebtoonSectionCacheStruct ) );
						using ( StreamReader streamReader = new StreamReader( GlobalVar.CACHE_DIRECTORY + "\\cache__" + id + ".dat" ) )
						{
							return ( T ) xmlSerializer.Deserialize( streamReader );
						}
					}
					else
					{
						return default( T );
					}
				default:
					return default( T );
			}
		}
	}
}
