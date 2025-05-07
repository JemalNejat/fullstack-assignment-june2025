using MySqlConnector;
using System.Data;
using SITE.ITEGAMAX._4._0._2.Models;
using SITE.ITEGAMAX._4._0._2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace SITE.ITEGAMAX._4._0._2.App_Code
{
    public class clDBMotor
    {

        private static readonly string? mariadbconnection = CLConnectionStrings.MariaDbConnectionString;


        #region "SITE CONTENT PAGES"
        public static modSitePage GetSitePageData(string itemfriendlyurl)
        {
            modSitePage sitepagedata = new modSitePage();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand("sp_get_site_page_content"))
                    {

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@pagestatus", SqlDbType.Int).Value = itemstatus;
                        cmd.Parameters.AddWithValue("@pagefriendlyurl", SqlDbType.VarChar).Value = itemfriendlyurl;
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                                sitepagedata.pageId = Convert.ToInt32(sdr["pageid"]);
                                sitepagedata.pageurlid = sdr["pageurlid"].ToString();
                                sitepagedata.pagetitle = sdr["pagetitle"].ToString();
                                sitepagedata.pagesubtitle = sdr["pagesubtitle"].ToString();
                                sitepagedata.pageshortdescription = sdr["pageshortdescription"].ToString();
                                sitepagedata.pagelayoutname = sdr["pagelayoutname"].ToString();
                                sitepagedata.pagecategoryid = Convert.ToInt32(sdr["pagecategoryid"]);
                                sitepagedata.pagetopbannerpic = sdr["pagetopbannerpic"].ToString();
                                sitepagedata.pagetopbannertitle = sdr["pagetopbannertitle"].ToString();
                                sitepagedata.pagetopbannersubtitle = sdr["pagetopbannersubtitle"].ToString();
                                sitepagedata.pagetopbannertext = sdr["pagetopbannertext"].ToString();
                                sitepagedata.pagemediumbannerpic = sdr["pagemediumbannerpic"].ToString();
                                sitepagedata.pagemediumbannertitle = sdr["pagemediumbannertitle"].ToString();
                                sitepagedata.pagemediumbannersubtitle = sdr["pagemediumbannersubtitle"].ToString();
                                sitepagedata.pagemediumbannertext = sdr["pagemediumbannertext"].ToString();
                                sitepagedata.pagesmallbannerpic = sdr["pagesmallbannerpic"].ToString();
                                sitepagedata.pagesmallbannertitle = sdr["pagesmallbannertitle"].ToString();
                                sitepagedata.pagesmallbannersubtitle = sdr["pagesmallbannersubtitle"].ToString();
                                sitepagedata.pagesmallbannertext = sdr["pagesmallbannertext"].ToString();
                                sitepagedata.pagemodifieddate = sdr["pagemodifieddate"].ToString();
                                sitepagedata.pagecreateddate = sdr["pagecreateddate"].ToString();
                                sitepagedata.pageupdateddate = sdr["pageupdateddate"].ToString();
                                sitepagedata.pagetype = Convert.ToInt32(sdr["pagetype"]);
                                sitepagedata.pagestatus = Convert.ToInt32(sdr["pagestatus"]);
                                sitepagedata.viewcount = Convert.ToInt32(sdr["viewcount"]);
                                sitepagedata.pagemenuarea = Convert.ToInt32(sdr["pagemenuarea"]);
                                sitepagedata.pageareaname = sdr["st_area_name"].ToString();
                                sitepagedata.pageareapath = sdr["st_area_path"].ToString();
                            }
                        }


                    }

                    // Fetch articles related to the page
                    if (sitepagedata.pageId > 0)
                    {
                        sitepagedata.Articles = FetchPageArticles(con, sitepagedata.pageId);
                        sitepagedata.SiteMetaTags = FetchMetaTags(con);
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    // Do exception catching here or rollbacktransaction if your using begin transact
                }
                finally
                {
                    con.Close();
                }
            }

            return sitepagedata;
        }

        public static modSitePage GetSitePageById(int pageid)
        {
            modSitePage sitepagedata = new modSitePage();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand("sp_get_site_page_byid"))
                    {

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@item_id", SqlDbType.Int).Value = pageid;
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                                sitepagedata.pageId = Convert.ToInt32(sdr["pageId"]);
                                sitepagedata.pageurlid = sdr["pageurlid"].ToString();
                                sitepagedata.pagetitle = sdr["pagetitle"].ToString();
                                sitepagedata.pagesubtitle = sdr["pagesubtitle"].ToString();
                                sitepagedata.pageshortdescription = sdr["pageshortdescription"].ToString();
                                sitepagedata.pagetopbannerpic = sdr["pagetopbannerpic"].ToString();
                                sitepagedata.pagetopbannertitle = sdr["pagetopbannertitle"].ToString();
                                sitepagedata.pagetopbannersubtitle = sdr["pagetopbannersubtitle"].ToString();
                                sitepagedata.pagetopbannertext = sdr["pagetopbannertext"].ToString();
                                sitepagedata.pagemediumbannerpic = sdr["pagemediumbannerpic"].ToString();
                                sitepagedata.pagemediumbannertitle = sdr["pagemediumbannertitle"].ToString();
                                sitepagedata.pagemediumbannersubtitle = sdr["pagemediumbannersubtitle"].ToString();
                                sitepagedata.pagemediumbannertext = sdr["pagemediumbannertext"].ToString();
                                sitepagedata.pagesmallbannerpic = sdr["pagesmallbannerpic"].ToString();
                                sitepagedata.pagesmallbannertitle = sdr["pagesmallbannertitle"].ToString();
                                sitepagedata.pagesmallbannersubtitle = sdr["pagesmallbannersubtitle"].ToString();
                                sitepagedata.pagesmallbannertext = sdr["pagesmallbannertext"].ToString();
                                sitepagedata.pagemenuarea = Convert.ToInt32(sdr["pagemenuarea"]);
                                sitepagedata.pagetype = Convert.ToInt32(sdr["pagetype"]);
                                sitepagedata.pageareaname = sdr["st_area_name"].ToString();
                                sitepagedata.pageareapath = sdr["st_area_path"].ToString();
                            }
                        }


                    }

                    // Fetch articles related to the page
                    if (sitepagedata.pageId > 0)
                    {
                        sitepagedata.Articles = FetchPageArticles(con, sitepagedata.pageId);
                        sitepagedata.SiteMetaTags = FetchMetaTags(con);
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    // Do exception catching here or rollbacktransaction if your using begin transact
                }
                finally
                {
                    con.Close();
                }
            }

            return sitepagedata;
        }

        public static List<modSitePage> GetSitePageListByArea(int areaid)
        {
            List<modSitePage> pagelist = new List<modSitePage>();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand("sp_get_site_pages_byarea"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@item_area", SqlDbType.Int).Value = areaid;

                        using (MySqlDataReader sdr2 = cmd.ExecuteReader())
                        {
                            while (sdr2.Read())
                            {
                                pagelist.Add(new modSitePage
                                {
                                    pageId = Convert.ToInt32(sdr2["pageId"]),
                                    pageurlid = sdr2["pageurlid"].ToString(),
                                    pagetitle = sdr2["pagetitle"].ToString(),
                                    pagesubtitle = sdr2["pagesubtitle"].ToString(),
                                    pageshortdescription = sdr2["pageshortdescription"].ToString(),
                                    pagetopbannerpic = sdr2["pagetopbannerpic"].ToString(),
                                    pagetopbannertitle = sdr2["pagetopbannertitle"].ToString(),
                                    pagetopbannersubtitle = sdr2["pagetopbannersubtitle"].ToString(),
                                    pagetopbannertext = sdr2["pagetopbannertext"].ToString(),
                                    pagemediumbannerpic = sdr2["pagemediumbannerpic"].ToString(),
                                    pagemediumbannertitle = sdr2["pagemediumbannertitle"].ToString(),
                                    pagemediumbannersubtitle = sdr2["pagemediumbannersubtitle"].ToString(),
                                    pagemediumbannertext = sdr2["pagemediumbannertext"].ToString(),
                                    pagesmallbannerpic = sdr2["pagesmallbannerpic"].ToString(),
                                    pagesmallbannertitle = sdr2["pagesmallbannertitle"].ToString(),
                                    pagesmallbannersubtitle = sdr2["pagesmallbannersubtitle"].ToString(),
                                    pagesmallbannertext = sdr2["pagesmallbannertext"].ToString(),
                                    pagemenuarea = Convert.ToInt32(sdr2["pagemenuarea"]),
                                    pagetype = Convert.ToInt32(sdr2["pagetype"]),
                                    pageareaname = sdr2["st_area_name"].ToString(),
                                    pageareapath = sdr2["st_area_path"].ToString()
                                });
                            }
                        }


                    }

                }
                catch (Exception)
                {
                    // Do exception catching here or rollbacktransaction if your using begin transact
                }
                finally
                {
                    con.Close();
                }
            }

            return pagelist;
        }

        public static modPageFAQ GetSitePageAndFAQ(int pageid, int faqarea)
        {
            modPageFAQ sitepagefaqdata = new modPageFAQ();

            sitepagefaqdata.SitePage = GetSitePageById(pageid);
            sitepagefaqdata.SiteFAQ = GetFAQbyArea(faqarea);

            return sitepagefaqdata;
        }

        private static List<modSitePageArticle> FetchPageArticles(MySqlConnection con, int pageId)
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

        private static modSiteMetaTags FetchMetaTags(MySqlConnection con)
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


        public static List<modFAQ> GetFAQbyArea(int areaid)
        {
            List<modFAQ> faqitems = new List<modFAQ>();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_faq_by_area"))
                {
                    try
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@areaid", SqlDbType.Int).Value = areaid;
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                faqitems.Add(new modFAQ
                                {
                                    st_faq_ques_ans_id = Convert.ToInt32(sdr["st_faq_ques_ans_id"]),
                                    st_faq_question = sdr["st_faq_question"].ToString(),
                                    st_faq_answer = sdr["st_faq_answer"].ToString(),
                                    st_faq_categoryid = Convert.ToInt32(sdr["st_faq_categoryid"]),
                                    st_faq_category_name = sdr["st_faq_category_name"].ToString()
                                });
                            }
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {

                        con.Close();
                    }
                }
            }
            return faqitems;
        }
        #endregion

        #region "SITEMAP"

        public static List<modSiteMap> GetSiteMapPages()
        {
            List<modSiteMap> pagelist = new List<modSiteMap>();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand("sp_get_site_map_pages"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataReader sdr2 = cmd.ExecuteReader())
                        {
                            while (sdr2.Read())
                            {
                                pagelist.Add(new modSiteMap
                                {
                                    pageId = Convert.ToInt32(sdr2["pageId"]),
                                    pageurlid = sdr2["pageurlid"].ToString(),
                                    pagetitle = sdr2["pagetitle"].ToString(),
                                    pagesubtitle = sdr2["pagesubtitle"].ToString(),
                                    pageshortdescription = sdr2["pageshortdescription"].ToString(),
                                    pagetopbannerpic = sdr2["pagetopbannerpic"].ToString(),
                                    pagetopbannertitle = sdr2["pagetopbannertitle"].ToString(),
                                    pagetopbannersubtitle = sdr2["pagetopbannersubtitle"].ToString(),
                                    pagetopbannertext = sdr2["pagetopbannertext"].ToString(),
                                    pagemediumbannerpic = sdr2["pagemediumbannerpic"].ToString(),
                                    pagemediumbannertitle = sdr2["pagemediumbannertitle"].ToString(),
                                    pagemediumbannersubtitle = sdr2["pagemediumbannersubtitle"].ToString(),
                                    pagemediumbannertext = sdr2["pagemediumbannertext"].ToString(),
                                    pagesmallbannerpic = sdr2["pagesmallbannerpic"].ToString(),
                                    pagesmallbannertitle = sdr2["pagesmallbannertitle"].ToString(),
                                    pagesmallbannersubtitle = sdr2["pagesmallbannersubtitle"].ToString(),
                                    pagesmallbannertext = sdr2["pagesmallbannertext"].ToString(),
                                    pagemenuarea = Convert.ToInt32(sdr2["pagemenuarea"]),
                                    pagetype = Convert.ToInt32(sdr2["pagetype"]),
                                    pageareaname = sdr2["st_area_name"].ToString(),
                                    pageareapath = sdr2["st_area_path"].ToString()
                                });
                            }
                        }


                    }

                }
                catch (Exception)
                {
                    // Do exception catching here or rollbacktransaction if your using begin transact
                }
                finally
                {
                    con.Close();
                }
            }

            return pagelist;
        }

        #endregion

        #region "SITE PRODUCTS"

        public static List<modProduct> GetProductListByGroup(int groupid)
        {
            List<modProduct> productlist = new List<modProduct>();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand("sp_get_product_by_group"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@groupid", MySqlDbType.Int32).Value = groupid;

                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                productlist.Add(new modProduct
                                {
                                    pd_id = Convert.ToInt32(sdr["pd_id"]),
                                    pd_name = sdr["pd_name"].ToString(),
                                    pd_description_short = sdr["pd_description_short"].ToString(),
                                    pd_description = sdr["pd_description"].ToString(),
                                    pd_text = sdr["pd_text"].ToString(),
                                    pd_type = sdr["pd_type"].ToString(),
                                    pd_group_id = Convert.ToInt32(sdr["pd_group_id"]),
                                    pd_category_id = Convert.ToInt32(sdr["pd_category_id"]),
                                    pd_page_id = Convert.ToInt32(sdr["pd_page_id"]),
                                    pd_position = Convert.ToInt32(sdr["pd_position"])
                                });
                            }
                        }
                    }

                    // Fetch the product features
                    foreach (var product in productlist)
                    {
                        if (product != null)
                        {
                            product.productfeatures = FetchProductFeatures(con, product.pd_id);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    // Log the exception (use proper logging mechanism)
                    throw new Exception("Error fetching site page data", ex);
                }
            }
            return productlist;
        }


        private static List<modProductFeature> FetchProductFeatures(MySqlConnection con, int productid)
        {
            var featureList = new List<modProductFeature>();

            using (MySqlCommand cmd = new MySqlCommand("sp_get_product_features"))
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productid", MySqlDbType.Int32).Value = productid;

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        featureList.Add(new modProductFeature
                        {
                            pf_id = Convert.ToInt32(sdr["pf_id"]),
                            pf_name = sdr["pf_name"].ToString(),
                            pf_category = Convert.ToInt32(sdr["pf_category"]),
                            pf_short_description = sdr["pf_short_description"].ToString(),
                            pf_productgroup_id = Convert.ToInt32(sdr["pf_productgroup_id"]),
                            pf_position = Convert.ToInt32(sdr["pf_position"]),
                            pfr_included = Convert.ToBoolean(sdr["pfr_included"]),
                            pfr_activated = Convert.ToBoolean(sdr["pfr_activated"])
                        });
                    }
                }
            }

            return featureList;
        }

        #endregion

        #region "MENU"
        public static List<modMenuItem> GetPageUnderMenuByArea(int areaid)
        {
            List<modMenuItem> listportalmenuitems = new List<modMenuItem>();

            using (MySqlConnection con = new MySqlConnection(mariadbconnection))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_menu_list"))
                {
                    try
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@item_area", SqlDbType.Int).Value = areaid;
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                listportalmenuitems.Add(new modMenuItem
                                {
                                    pageId = Convert.ToInt32(sdr["pageId"]),
                                    pageurlid = sdr["pageurlid"].ToString(),
                                    pagetitle = sdr["pagetitle"].ToString(),
                                    pagemenuarea = Convert.ToInt32(sdr["pagemenuarea"]),
                                    pagetype = Convert.ToInt32(sdr["pagetype"])
                                });
                            }
                        }
                        con.Close();
                    }
                    catch (MySqlException)
                    {

                        con.Close();
                    }
                }
            }
            return listportalmenuitems;
        }
        #endregion
    }

}