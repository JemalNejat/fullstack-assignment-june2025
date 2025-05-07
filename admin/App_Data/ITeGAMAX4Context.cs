
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public partial class ITeGAMAX4Context : DbContext
    {
        public ITeGAMAX4Context()
        {
        }

        public ITeGAMAX4Context(DbContextOptions<ITeGAMAX4Context> options)
            : base(options)
        {
        }



        public virtual DbSet<StFaqQuestions> StFaqQuestionsProp { get; set; }
        public virtual DbSet<StIsCustomer> StIsCustomers { get; set; }
        public virtual DbSet<StMetatag> StMetatags { get; set; }
        public virtual DbSet<StNewsletterSubscriber> StNewsletterSubscribers { get; set; }

        public virtual DbSet<StSocialMedia> StSocialMedias { get; set; }

        public virtual DbSet<SvcEmailMessage> SvcEmailMessages { get; set; }

        public virtual DbSet<StPageArticle> StPageArticles { get; set; }

        public virtual DbSet<StContactIssue> StContactIssues { get; set; }
        public virtual DbSet<StObjViewLog> StObjectViewLogs { get; set; }
        public virtual DbSet<SyStatus> SyStatuses { get; set; }

        public virtual DbSet<StContactArea> StContactAreas { get; set; }

        public virtual DbSet<EmailAttachment> EmailAttachments { get; set; }

        public virtual DbSet<StFaqArea> StFaqAreas { get; set; }

        public virtual DbSet<StFaqCategory> StFaqCategories { get; set; }
        public virtual DbSet<StPage> StPages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StFaqQuestions>(entity =>
            {
                entity.HasKey(e => e.StFaqQuesAnsId).HasName("Primary");

                entity.ToTable("st_faq_question_answers");

                entity.Property(e => e.StFaqQuesAnsId)
                    .HasColumnName("st_faq_ques_ans_id")
                    .IsRequired()
                    .ValueGeneratedOnAdd(); // Auto increment field, no need to manually set this.

                entity.Property(e => e.StFaqQuestion)
                    .HasColumnName("st_faq_question")
                    .HasMaxLength(500)
                    .IsRequired(false); // Nullable field

                entity.Property(e => e.StFaqAnswer)
                    .HasColumnName("st_faq_answer")
                    .HasMaxLength(2000)
                    .IsRequired(false); // Nullable field

                entity.Property(e => e.StFaqCategoryid)
                    .HasColumnName("st_faq_categoryid")
                    .HasDefaultValue(0) // Default value
                    .IsRequired(false); // Nullable field

                entity.Property(e => e.StFaqQuesAnsStatus)
                    .HasColumnName("st_faq_ques_ans_status")
                    .HasDefaultValue(3) // Default value
                    .IsRequired(false); // Nullable field

                entity.Property(e => e.StFaqQuesAnsCreateddate)
                    .HasColumnName("st_faq_ques_ans_createddate")
                    .HasColumnType("datetime")
                    .IsRequired(false); // Nullable field

                entity.Property(e => e.StFaqQuesAnsUpdateddate)
                    .HasColumnName("st_faq_ques_ans_updateddate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP") // Default value for timestamp
                    .IsRequired(false); // Nullable field

                entity.Property(e => e.Viewcount)
                    .HasColumnName("viewcount")
                    .HasDefaultValue(0) // Default value
                    .IsRequired(false); // Nullable field
            });
            modelBuilder.Entity<StMetatag>(entity =>
            {
                entity.HasKey(e => e.StMetatagid).HasName("PRIMARY");

                entity.ToTable("st_metatags");

                entity.Property(e => e.StMetatagid)
                    .HasColumnName("st_metatagid");

                entity.Property(e => e.Metaauthor)
                    .HasMaxLength(500)
                    .HasColumnName("metaauthor");

                entity.Property(e => e.Metadescription)
                    .HasMaxLength(500)
                    .HasColumnName("metadescription");

                entity.Property(e => e.Metakeywords)
                    .HasMaxLength(500)
                    .HasColumnName("metakeywords");

                entity.Property(e => e.Metalinkhref)
                    .HasMaxLength(500)
                    .HasColumnName("metalinkhref");

                entity.Property(e => e.Metalinkrelcanonical)
                    .HasMaxLength(500)
                    .HasColumnName("metalinkrelcanonical");

                entity.Property(e => e.Metanamerobots)
                    .HasMaxLength(500)
                    .HasColumnName("metanamerobots");

                entity.Property(e => e.MetapropCreateddate)
                    .HasColumnType("datetime")
                    .HasColumnName("metaprop_createddate");

                entity.Property(e => e.MetapropStatus)
                    .HasDefaultValue(3)
                    .HasColumnName("metaprop_status");

                entity.Property(e => e.MetapropUpdateddate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("metaprop_updateddate");

                entity.Property(e => e.MetapropertyogDescription)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_description");

                entity.Property(e => e.MetapropertyogImage)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_image");

                entity.Property(e => e.MetapropertyogLocale)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_locale");

                entity.Property(e => e.MetapropertyogSiteName)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_site_name");

                entity.Property(e => e.MetapropertyogTitle)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_title");

                entity.Property(e => e.MetapropertyogType)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_type");

                entity.Property(e => e.MetapropertyogUrl)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertyog_url");

                entity.Property(e => e.MetapropertytwitterCreator)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertytwitter_creator");

                entity.Property(e => e.MetapropertytwitterDescription)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertytwitter_description");

                entity.Property(e => e.MetapropertytwitterImage)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertytwitter_image");

                entity.Property(e => e.MetapropertytwitterSite)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertytwitter_site");

                entity.Property(e => e.MetapropertytwitterTitle)
                    .HasMaxLength(500)
                    .HasColumnName("metapropertytwitter_title");

                entity.Property(e => e.Metatitle)
                    .HasMaxLength(500)
                    .HasColumnName("metatitle");

                entity.Property(e => e.StMetatagSitetype)
                    .HasDefaultValue(1)
                    .HasColumnName("st_metatag_sitetype");

                entity.Property(e => e.Viewcount)
                    .HasDefaultValue(0)
                    .HasColumnName("viewcount");
            });
            modelBuilder.Entity<StNewsletterSubscriber>(entity =>
            {
                entity.HasKey(e => e.StNlSubscribersId).HasName("PRIMARY");

                entity.ToTable("st_newsletter_subscribers");

                entity.HasIndex(e => e.StNlSubscribersId, "idst_nl_subscribers_id_UNIQUE").IsUnique();

                entity.Property(e => e.StNlSubscribersId)
                    .HasColumnType("int(11)")
                    .HasColumnName("st_nl_subscribers_id");
                entity.Property(e => e.StNlSubscribersComType)
                    .HasDefaultValueSql("'1'")
                    .HasColumnType("int(11)")
                    .HasColumnName("st_nl_subscribers_com_type");
                entity.Property(e => e.StNlSubscribersCreateddate)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_nl_subscribers_createddate");
                entity.Property(e => e.StNlSubscribersEmail)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("st_nl_subscribers_email");
                entity.Property(e => e.StNlSubscribersName)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("st_nl_subscribers_name");
                entity.Property(e => e.StNlSubscribersOpout)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("st_nl_subscribers_opout");
                entity.Property(e => e.StNlSubscribersOpoutDate)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_nl_subscribers_opout_date");
                entity.Property(e => e.StNlSubscribersPhone)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("st_nl_subscribers_phone");
                entity.Property(e => e.StNlSubscribersStarea)
                    .HasDefaultValueSql("'1'")
                    .HasColumnType("int(11)")
                    .HasColumnName("st_nl_subscribers_starea");
                entity.Property(e => e.StNlSubscribersStatus)
                    .HasDefaultValueSql("'3'")
                    .HasColumnType("int(11)")
                    .HasColumnName("st_nl_subscribers_status");
                entity.Property(e => e.StNlSubscribersUpdateddate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_nl_subscribers_updateddate");
            });
            modelBuilder.Entity<StIsCustomer>(entity =>
            {

                entity.HasKey(e => e.StIsCustomerId).HasName("Primary");

                entity.ToTable("st_iscustomer");

                entity.Property(e => e.StIsCustomerId)
                    .HasColumnName("st_iscustomet_id")
                    .IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.StIsCustomerName)
                    .HasColumnName("st_iscustomer_name")
                    .HasMaxLength(45)
                    .IsRequired(false);

                entity.Property(e => e.StIsCustomerStatus)
                .HasColumnName("st_iscustomer_status")
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValue(3);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .IsRequired()
                    .HasColumnType("int")
                    .HasDefaultValue(1);
            });

            modelBuilder.Entity<StSocialMedia>(entity =>
            {
                entity.HasKey(e => e.StSocialMediaId).HasName("PRIMARY");

                entity.ToTable("st_social_media");

                entity.Property(e => e.StSocialMediaId)
                .HasColumnType("int(11)")
                .HasColumnName("st_social_media_id");
                entity.Property(e => e.StSocialMediaName)
                    .HasMaxLength(45)
                    .HasColumnName("st_social_media_name");
                entity.Property(e => e.StSocialMediaShort)
                    .HasMaxLength(45)
                    .HasColumnName("st_social_media_short");
                entity.Property(e => e.StSocialMediaStatus)
                    .HasDefaultValueSql("'3'")
                    .HasColumnType("int(11)")
                    .HasColumnName("st_social_media_status");

                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");

                entity.Property(e => e.StSocialMediaCreatedDate)
                   .HasColumnName("st_social_media_createddate")
                   .HasColumnType("datetime");

                entity.Property(e => e.StSocialMediaUpdateDate)
                    .HasColumnName("st_social_media_updatedate")
                    .HasColumnType("datetime");

            });

            modelBuilder.Entity<SvcEmailMessage>(entity =>
            {
                entity.HasKey(e => e.SEMsgId).HasName("Primary");

                entity.ToTable("svc_email_messages");

                entity.Property(e => e.SEMsgId)
                    .HasColumnName("svc_e_mssg_id")
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.SEMsgFrom)
                    .HasColumnName("svc_e_mssg_from")
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.SEMsgFromName)
                    .HasColumnName("svc_e_mssg_fromname")
                    .HasMaxLength(45);

                entity.Property(e => e.SEMsgTo)
                    .HasColumnName("svc_e_mssg_to")
                    .HasMaxLength(45);

                entity.Property(e => e.SEMsgToName)
                    .HasColumnName("svc_e_mssg_toname")
                    .HasMaxLength(45);

                entity.Property(e => e.SEMsgReplyTo)
                    .HasColumnName("svc_e_mssg_replyto")
                    .HasMaxLength(45);

                entity.Property(e => e.SEMsgSubject)
                    .HasColumnName("svc_e_mssg_subject")
                    .HasMaxLength(255);

                entity.Property(e => e.SEMsgIsHtml)
                    .HasColumnName("svc_e_mssg_ishtml")
                    .IsRequired()
                   .HasColumnType("tinyint(4)");

                entity.Property(e => e.SEMsgBodyHtml)
                    .HasColumnName("svc_e_mssg_bodyhtml")
                    .HasColumnType("text");

                entity.Property(e => e.SEMsgHasAttachments)
                    .HasColumnName("svc_e_mssg_hasattachments")
                    .IsRequired()
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.SEMsgCreatedDate)
                    .HasColumnName("svc_e_mssg_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.SEMsgUpdatedDate)
                    .HasColumnName("svc_e_mssg_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.SEMsgSystem)
                    .HasColumnName("svc_e_mssg_system")
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.SEMsgStatus)
                    .HasColumnName("svc_e_mssg_status")
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.SEMsgSentDate)
                    .HasColumnName("svc_e_mssg_sentdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");
            });

            modelBuilder.Entity<StFaqArea>(entity =>
            {
                entity.HasKey(e => e.StFaqAreaId).HasName("PRIMARY");

                entity.ToTable("st_faq_area");

                entity.HasIndex(e => e.StFaqAreaId, "st_faq_area_id_UNIQUE").IsUnique();

                entity.Property(e => e.StFaqAreaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("st_faq_area_id");

                entity.Property(e => e.StFaqAreaDescription)
                    .HasMaxLength(500)
                    .HasColumnName("st_faq_area_description");

                entity.Property(e => e.StFaqAreaName)
                    .HasMaxLength(45)
                    .HasColumnName("st_faq_area_name");

                entity.Property(e => e.StFaqAreaStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("st_faq_area_status");

                entity.Property(e => e.Viewcount)
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");

                // StFaqCreatedDate Property
                entity.Property(e => e.StFaqCreatedDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("st_faq_created_date")
                    .IsRequired(false); // Allow NULL

                // StFaqUpdatedDate Property
                entity.Property(e => e.StFaqUpdatedDate) // Added for updated timestamp
                    .HasColumnType("DATETIME")
                    .HasColumnName("st_faq_updated_date")
                    .IsRequired(true) // Not nullable
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");


            });

            modelBuilder.Entity<StPageArticle>(entity =>
            {
                entity.HasKey(e => e.StArticleId).HasName("PRIMARY");

                entity.ToTable("st_page_articles");

                entity.HasIndex(e => e.StArticleId, "st_article_id_UNIQUE").IsUnique();

                entity.Property(e => e.StArticleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("st_article_id");
                entity.Property(e => e.ArticlePicture)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("article_picture");
                entity.Property(e => e.ArticlePictureAlign)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("article_picture_align");
                entity.Property(e => e.ArticlePictureLinktarget)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("article_picture_linktarget");
                entity.Property(e => e.ArticlePictureLinktitle)
                    .HasMaxLength(55)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("article_picture_linktitle");
                entity.Property(e => e.ArticlePictureLinkurl)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("article_picture_linkurl");
                entity.Property(e => e.ArticlePosition)
                    .HasDefaultValueSql("'1'")
                    .HasColumnType("int(11)")
                    .HasColumnName("article_position");
                entity.Property(e => e.Articlecreateddate)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("articlecreateddate");
                entity.Property(e => e.ArticlestStatus)
                    .HasDefaultValueSql("'2'")
                    .HasColumnType("int(11)")
                    .HasColumnName("articlest_status");
                entity.Property(e => e.Articlesubtitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("articlesubtitle");
                entity.Property(e => e.Articletext)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("articletext");
                entity.Property(e => e.Articletitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("articletitle");
                entity.Property(e => e.Articleupdatedate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("articleupdatedate");
                entity.Property(e => e.StPageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("st_page_id");
                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");
            });

            modelBuilder.Entity<StObjViewLog>(entity =>
            {
                entity.HasKey(e => e.StObjVlId).HasName("PRIMARY");

                entity.ToTable("st_object_view_log");

                entity.HasIndex(e => e.StObjVlId, "st_oj_vl_id_UNIQUE").IsUnique();

				entity.Property(e => e.StObjVlId)
					.HasColumnType("int(11)")
					.HasColumnName("st_obj_vl_id");
				entity.Property(e => e.StCreateddate)
					.HasDefaultValueSql("'current_timestamp()'")
					.HasColumnType("datetime")
					.HasColumnName("st_createddate");
                entity.Property(e => e.StUpdateddate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_updateddate");
                entity.Property(e => e.StObjId)
					.HasColumnType("int(11)")
					.HasColumnName("st_obj_id");
				entity.Property(e => e.StObjType)
					.HasColumnType("int(11)")
					.HasColumnName("st_obj_type");
                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");
            });
			modelBuilder.Entity<StContactIssue>(entity =>
			{
				entity.HasKey(e => e.StCtIssueId).HasName("PRIMARY");

                entity.ToTable("st_contact_issues");

                entity.HasIndex(e => e.StCtIssueId, "st_ct_issue_id_UNIQUE").IsUnique();

				entity.Property(e => e.StCtIssueId)
					.HasColumnType("int(11)")
					.HasColumnName("st_ct_issue_id");
				entity.Property(e => e.StCtIssueArea)
					.HasColumnType("int(11)")
					.HasColumnName("st_ct_issue_area");
				entity.Property(e => e.StCtIssueComfirmEmail)
					.HasColumnType("tinyint(4)")
					.HasColumnName("st_ct_issue_comfirm_email");
				entity.Property(e => e.StCtIssueCustName)
					.HasMaxLength(45)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_ct_issue_cust_name");
				entity.Property(e => e.StCtIssueEmail)
					.HasMaxLength(45)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_ct_issue_email");
				entity.Property(e => e.StCtIssueIscustomer)
					.HasColumnType("int(11)")
					.HasColumnName("st_ct_issue_iscustomer");
				entity.Property(e => e.StCtIssuePhone)
					.HasMaxLength(20)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_ct_issue_phone");
                entity.Property(e => e.StCtIssueCreateddate)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_ct_issue_createddate");
                entity.Property(e => e.StCtIssueUpdateddate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_ct_issue_updateddate");
                entity.Property(e => e.StCtIssueStatus)
					.HasDefaultValueSql("'3'")
					.HasColumnType("int(11)")
					.HasColumnName("st_ct_issue_status");
                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");
                entity.Property(e => e.StCtIssueSubject)
					.HasMaxLength(255)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_ct_issue_subject");
				entity.Property(e => e.StCtIssueText)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_ct_issue_text");
				
			});
			modelBuilder.Entity<StContactArea>(entity =>
			{
				entity.HasKey(e => e.StContactAreaId).HasName("PRIMARY");

                entity.ToTable("st_contact_area");

                entity.HasIndex(e => e.StContactAreaId, "st_contact_area_id_UNIQUE").IsUnique();

				entity.Property(e => e.StContactAreaId)
					.HasColumnType("int(11)")
					.HasColumnName("st_contact_area_id");
				entity.Property(e => e.Position)
					.HasDefaultValueSql("'1'")
					.HasColumnType("int(11)")
					.HasColumnName("position");
				entity.Property(e => e.StContactAreaName)
					.HasMaxLength(45)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_contact_area_name");
				entity.Property(e => e.StContactAreaStatus)
					.HasDefaultValueSql("'3'")
					.HasColumnType("int(11)")
					.HasColumnName("st_contact_area_status");
                entity.Property(e => e.StCreatedDate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_created_date");
                entity.Property(e => e.StUpdatedDate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("st_updated_date");
                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");
            });
			modelBuilder.Entity<StFaqCategory>(entity =>
			{
				entity.HasKey(e => e.StFaqCategoryId).HasName("PRIMARY");

                entity.ToTable("st_faq_categories");

                entity.HasIndex(e => e.StFaqCategoryId, "st_faq_category_id_UNIQUE").IsUnique();

				entity.Property(e => e.StFaqCategoryId)
					.HasColumnType("int(11)")
					.HasColumnName("st_faq_category_id");
				entity.Property(e => e.StFaqAreaId)
					.HasDefaultValueSql("'0'")
					.HasColumnType("int(11)")
					.HasColumnName("st_faq_area_id");
				entity.Property(e => e.StFaqCategoryDescription)
					.HasMaxLength(500)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_faq_category_description");
				entity.Property(e => e.StFaqCategoryName)
					.HasMaxLength(45)
					.HasDefaultValueSql("'NULL'")
					.HasColumnName("st_faq_category_name");
				entity.Property(e => e.StFaqCategoryStatus)
					.HasDefaultValueSql("'3'")
					.HasColumnType("int(11)")
					.HasColumnName("st_faq_category_status");
                entity.Property(e => e.StFaqCreatedDate)
                   .HasColumnType("DATETIME")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                 .HasColumnName("st_faq_created_date");  // <-- Update column name

                entity.Property(e => e.StFaqUpdatedDate)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnName("st_faq_updated_date");  // <-- Update column name

                entity.Property(e => e.Viewcount)
					.HasDefaultValueSql("'0'")
					.HasColumnType("int(11)")
					.HasColumnName("viewcount");
			});
			modelBuilder.Entity<EmailAttachment>(entity =>
			{
				entity.HasKey(e => e.EmssgAttachId).HasName("PRIMARY"); // Primary Key

                entity.ToTable("svc_email_messages_attachments"); // Table name in the database

                // Property configurations
                entity.Property(e => e.EmssgAttachId)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("emssg_attach_id");

                entity.Property(e => e.EmssgId)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("emssg_id");

                entity.Property(e => e.EmssgAttachFileName)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("emssg_attach_filename");

                entity.Property(e => e.EmssgAttachDownloadUrl)
                    .HasColumnType("varchar(500)")
                    .HasColumnName("emssg_attach_downloadurl")
                    .IsRequired(false); // Optional field

                entity.Property(e => e.EmssgAttachFileType)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("emssg_attach_filetype");

                entity.Property(e => e.EmssgAttachCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("emssg_attach_created")
                    .HasDefaultValueSql("current_timestamp()");

				entity.Property(e => e.EmssgAttachSend)
					.HasColumnType("tinyint(4)")
					.HasColumnName("emssg_attach_send")
					.HasDefaultValue(0); // Default value of

                // New properties to be added
                entity.Property(e => e.EmssgAttachUpdatedDate) // Added for updated timestamp
                    .HasColumnType("datetime")
                    .HasColumnName("emssg_attach_updateddate")
                    .IsRequired(true) // Not nullable
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"); // Auto-update on modification

                entity.Property(e => e.ViewCount) // Added for tracking view count
                    .HasColumnType("int(11)")
                    .HasColumnName("ViewCount")
                    .HasDefaultValue(0); // De

            });
			modelBuilder.Entity<StPage>(entity =>
			{
				entity.HasKey(e => e.PageId).HasName("PRIMARY");

                entity.ToTable("st_pages");

                entity.HasIndex(e => e.PageId, "pageId_UNIQUE").IsUnique();

                entity.Property(e => e.PageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pageId");
                entity.Property(e => e.Pagecategoryid)
                    .HasDefaultValueSql("'1'")
                    .HasColumnType("int(11)")
                    .HasColumnName("pagecategoryid");
                entity.Property(e => e.Pagecreateddate)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("pagecreateddate");
                entity.Property(e => e.Pagelayoutname)
                    .HasMaxLength(55)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagelayoutname");
                entity.Property(e => e.Pagemediumbannerpic)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagemediumbannerpic");
                entity.Property(e => e.Pagemediumbannersubtitle)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagemediumbannersubtitle");
                entity.Property(e => e.Pagemediumbannertext)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagemediumbannertext");
                entity.Property(e => e.Pagemediumbannertitle)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagemediumbannertitle");
                entity.Property(e => e.Pagemenuarea)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("pagemenuarea");
                entity.Property(e => e.Pagemodifieddate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("pagemodifieddate");
                entity.Property(e => e.Pageshortdescription)
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pageshortdescription");
                entity.Property(e => e.Pagesmallbannerpic)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagesmallbannerpic");
                entity.Property(e => e.Pagesmallbannersubtitle)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagesmallbannersubtitle");
                entity.Property(e => e.Pagesmallbannertext)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagesmallbannertext");
                entity.Property(e => e.Pagesmallbannertitle)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagesmallbannertitle");
                entity.Property(e => e.Pagestatus)
                    .HasDefaultValueSql("'2'")
                    .HasColumnType("int(11)")
                    .HasColumnName("pagestatus");
                entity.Property(e => e.Pagesubtitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagesubtitle");
                entity.Property(e => e.Pagetitle)
                    .HasMaxLength(255)
                    .HasColumnName("pagetitle");
                entity.Property(e => e.Pagetopbannerpic)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagetopbannerpic");
                entity.Property(e => e.Pagetopbannersubtitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagetopbannersubtitle");
                entity.Property(e => e.Pagetopbannertext)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagetopbannertext");
                entity.Property(e => e.Pagetopbannertitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("pagetopbannertitle");
                entity.Property(e => e.Pagetype)
                    .HasDefaultValueSql("'1'")
                    .HasColumnType("int(11)")
                    .HasColumnName("pagetype");
                entity.Property(e => e.Pageupdateddate)
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasColumnType("datetime")
                    .HasColumnName("pageupdateddate");
                entity.Property(e => e.Pageurlid)
                    .HasMaxLength(255)
                    .HasColumnName("pageurlid");
                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");
            });


            modelBuilder.Entity<SyStatus>(entity =>
            {
                entity.HasKey(s => s.id).HasName("PRIMARY");

                entity.ToTable("sy_statuses");

                entity.Property(s => s.id)
                    .HasColumnName("sy_status_id");

                entity.Property(s => s.Status)
                      .HasMaxLength(45)
                      .HasColumnName("sy_status_name");

                entity.Property(e => e.Viewcount)
                    .HasDefaultValueSql("'0'")
                    .HasColumnType("int(11)")
                    .HasColumnName("viewcount");

                entity.Property(e => e.SyCreatedDate)
                   .HasColumnName("sy_status_createddate")
                   .HasColumnType("datetime");

                entity.Property(e => e.SyUpdateDate)
                    .HasColumnName("sy_status_updatedate")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
