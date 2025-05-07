using MySqlConnector;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;
using System.Data;

namespace SITE.ITEGAMAX._4._0._2.Services
{
    public interface IContentService
    {
        modSitePage GetSitePageData(string itemFriendlyUrl);
    }

    public class ContentService : IContentService
    {
        private static readonly string? _mariaDbConnection = CLConnectionStrings.MariaDbConnectionString;

        public modSitePage GetSitePageData(string itemFriendlyUrl)
        {
            modSitePage sitePageData = new modSitePage();

            using (MySqlConnection con = new MySqlConnection(_mariaDbConnection))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_get_site_page_content"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pagefriendlyurl", MySqlDbType.VarChar).Value = itemFriendlyUrl;

                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                sitePageData.pageId = Convert.ToInt32(sdr["pageid"]);
                                sitePageData.pageurlid = sdr["pageurlid"].ToString();
                                sitePageData.pagetitle = sdr["pagetitle"].ToString();
                                sitePageData.pagesubtitle = sdr["pagesubtitle"].ToString();
                                sitePageData.pageshortdescription = sdr["pageshortdescription"].ToString();
                                sitePageData.pagelayoutname = sdr["pagelayoutname"].ToString();
                                sitePageData.pagecategoryid = Convert.ToInt32(sdr["pagecategoryid"]);
                                sitePageData.pagetopbannerpic = sdr["pagetopbannerpic"].ToString();
                                sitePageData.pagetopbannertitle = sdr["pagetopbannertitle"].ToString();
                                sitePageData.pagetopbannersubtitle = sdr["pagetopbannersubtitle"].ToString();
                                sitePageData.pagetopbannertext = sdr["pagetopbannertext"].ToString();
                                sitePageData.pagemediumbannerpic = sdr["pagemediumbannerpic"].ToString();
                                sitePageData.pagemediumbannertitle = sdr["pagemediumbannertitle"].ToString();
                                sitePageData.pagemediumbannersubtitle = sdr["pagemediumbannersubtitle"].ToString();
                                sitePageData.pagemediumbannertext = sdr["pagemediumbannertext"].ToString();
                                sitePageData.pagesmallbannerpic = sdr["pagesmallbannerpic"].ToString();
                                sitePageData.pagesmallbannertitle = sdr["pagesmallbannertitle"].ToString();
                                sitePageData.pagesmallbannersubtitle = sdr["pagesmallbannersubtitle"].ToString();
                                sitePageData.pagesmallbannertext = sdr["pagesmallbannertext"].ToString();
                                sitePageData.pagemodifieddate = sdr["pagemodifieddate"].ToString();
                                sitePageData.pagecreateddate = sdr["pagecreateddate"].ToString();
                                sitePageData.pageupdateddate = sdr["pageupdateddate"].ToString();
                                sitePageData.pagetype = Convert.ToInt32(sdr["pagetype"]);
                                sitePageData.pagestatus = Convert.ToInt32(sdr["pagestatus"]);
                                sitePageData.viewcount = Convert.ToInt32(sdr["viewcount"]);
                                sitePageData.pagemenuarea = Convert.ToInt32(sdr["pagemenuarea"]);
                                sitePageData.pageareaname = sdr["st_area_name"].ToString();
                                sitePageData.pageareapath = sdr["st_area_path"].ToString();
                            }
                        }
                    }

                    // Fetch articles related to the page
                    if (sitePageData.pageId > 0)
                    {
                        sitePageData.Articles = FetchPageArticles(con, sitePageData.pageId);
                        sitePageData.SiteMetaTags = FetchMetaTags(con);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    // Log the exception (use proper logging mechanism)
                    throw new Exception("Error fetching site page data", ex);
                }
            }

            return sitePageData;
        }

        private List<modSitePageArticle> FetchPageArticles(MySqlConnection con, int pageId)
        {
            var articleList = new List<modSitePageArticle>();

            using (MySqlCommand cmd = new MySqlCommand("sp_get_site_page_articles"))
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sitepageid", MySqlDbType.Int32).Value = pageId;

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        articleList.Add(new modSitePageArticle
                        {
                            st_article_id = Convert.ToInt32(sdr["st_article_id"]),
                            articletitle = sdr["articletitle"].ToString(),
                            articlesubtitle = sdr["articlesubtitle"].ToString(),
                            articletext = sdr["articletext"].ToString(),
                            st_page_id = Convert.ToInt32(sdr["st_page_id"]),
                            articlecreateddate = sdr["articlecreateddate"].ToString(),
                            articleupdatedate = sdr["articleupdatedate"].ToString(),
                            articlest_status = Convert.ToInt32(sdr["articlest_status"]),
                            article_picture = sdr["article_picture"].ToString(),
                            article_picture_align = sdr["article_picture_align"].ToString(),
                            article_picture_linktitle = sdr["article_picture_linktitle"].ToString(),
                            article_picture_linkurl = sdr["article_picture_linkurl"].ToString(),
                            article_picture_linktarget = sdr["article_picture_linktarget"].ToString(),
                            article_position = Convert.ToInt32(sdr["article_position"]),
                            viewcount = Convert.ToInt32(sdr["viewcount"])
                        });
                    }
                }
            }

            return articleList;
        }

        private modSiteMetaTags FetchMetaTags(MySqlConnection con)
        {
            var metaTags = new modSiteMetaTags();

            using (MySqlCommand cmd = new MySqlCommand("sp_get_site_metatags"))
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@metatagssite", MySqlDbType.Int32).Value = CLCustAppsettings.SITE_ID;

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        metaTags.st_metatagid = Convert.ToInt32(sdr["st_metatagid"]);
                        metaTags.st_metatag_sitetype = Convert.ToInt32(sdr["st_metatag_sitetype"]);
                        metaTags.metatitle = sdr["metatitle"].ToString();
                        metaTags.metadescription = sdr["metadescription"].ToString();
                        metaTags.metakeywords = sdr["metakeywords"].ToString();
                        metaTags.metaauthor = sdr["metaauthor"].ToString();
                        metaTags.metalinkhref = sdr["metalinkhref"].ToString();
                        metaTags.metalinkrelcanonical = sdr["metalinkrelcanonical"].ToString();
                        metaTags.metanamerobots = sdr["metanamerobots"].ToString();
                        metaTags.metapropertyog_type = sdr["metapropertyog_type"].ToString();
                        metaTags.metapropertyog_title = sdr["metapropertyog_title"].ToString();
                        metaTags.metapropertyog_description = sdr["metapropertyog_description"].ToString();
                        metaTags.metapropertyog_image = sdr["metapropertyog_image"].ToString();
                        metaTags.metapropertyog_url = sdr["metapropertyog_url"].ToString();
                        metaTags.metapropertyog_site_name = sdr["metapropertyog_site_name"].ToString();
                        metaTags.metapropertyog_locale = sdr["metapropertyog_locale"].ToString();
                        metaTags.metapropertytwitter_title = sdr["metapropertytwitter_title"].ToString();
                        metaTags.metapropertytwitter_description = sdr["metapropertytwitter_description"].ToString();
                        metaTags.metapropertytwitter_image = sdr["metapropertytwitter_image"].ToString();
                        metaTags.metapropertytwitter_site = sdr["metapropertytwitter_site"].ToString();
                        metaTags.metapropertytwitter_creator = sdr["metapropertytwitter_creator"].ToString();
                        metaTags.metaprop_createddate = sdr["metaprop_createddate"].ToString();
                        metaTags.metaprop_updateddate = sdr["metaprop_updateddate"].ToString();
                        metaTags.metaprop_status = Convert.ToInt32(sdr["metaprop_status"]);
                        metaTags.viewcount = Convert.ToInt32(sdr["viewcount"]);
                    }
                }
            }

            return metaTags;
        }
    }


}
