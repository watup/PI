USE [PharmacyInterventions]
GO
SET IDENTITY_INSERT [dbo].[InterventionTypeCategory] ON 

GO
INSERT [dbo].[InterventionTypeCategory] ([Id], [Name], [IsActive], [DisplayOrder]) VALUES (1, N'Perscription', 1, 1)
GO
INSERT [dbo].[InterventionTypeCategory] ([Id], [Name], [IsActive], [DisplayOrder]) VALUES (2, N'Transcription', 1, 2)
GO
INSERT [dbo].[InterventionTypeCategory] ([Id], [Name], [IsActive], [DisplayOrder]) VALUES (3, N'Supply', 1, 3)
GO
INSERT [dbo].[InterventionTypeCategory] ([Id], [Name], [IsActive], [DisplayOrder]) VALUES (4, N'Administration', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[InterventionTypeCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[InterventionType] ON 

GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (1, 1, N'Omission', 1, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (2, 1, N'Wrong does regimen', 3, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (3, 1, N'ADR', 2, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (4, 1, N'Interaction', 4, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (5, 1, N'Wrong route', 5, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (6, 1, N'Illegible/inomplete details', 7, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (7, 1, N'Allergy', 9, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (8, 1, N'Contraindication', 11, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (9, 1, N'Wrong drug', 6, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (11, 1, N'Duplicate therapy', 8, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (12, 1, N'Inappropriate', 10, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (13, 2, N'Omission', 1, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (14, 2, N'Wrong route', 2, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (15, 2, N'Illegible/incomplete details', 5, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (16, 2, N'Wrong drug', 3, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (17, 2, N'Wrong does regimen', 4, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (18, 3, N'Expired', 1, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (19, 3, N'Labelling error', 2, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (20, 3, N'Dispensing error', 3, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (21, 3, N'Pyxis error', 4, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (22, 4, N'Omission', 1, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (23, 4, N'Wrong route', 2, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (24, 4, N'Documentation', 3, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (25, 4, N'Wrong drug', 4, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (26, 4, N'Extra dose', 5, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (27, 4, N'Formulation', 6, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (28, 4, N'Wrong dose/rate/volume', 7, 1)
GO
INSERT [dbo].[InterventionType] ([Id], [InterventionTypeCategoryId], [Name], [DisplayOrder], [IsActive]) VALUES (29, 4, N'Self-medication related', 8, 1)
GO
SET IDENTITY_INSERT [dbo].[InterventionType] OFF
GO
SET IDENTITY_INSERT [dbo].[ContributionType] ON 

GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (1, N'Availability/funding/costing', 1, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (2, N'IV/Oral switch', 2, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (3, N'Administration/formulation advice', 3, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (4, N'Therapeutics', 4, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (5, N'TDM/Labs', 5, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (6, N'Duration of therapy', 6, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (7, N'Adverse drug reaction', 7, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (8, N'Patient education/compliance', 8, 1)
GO
INSERT [dbo].[ContributionType] ([Id], [Name], [DisplayOrder], [IsActive]) VALUES (9, N'Interaction advice', 9, 1)
GO
SET IDENTITY_INSERT [dbo].[ContributionType] OFF
GO
INSERT [dbo].[InterventionGrade] ([Value], [Description], [Example]) VALUES (1, N'No harm or only minor harm – not requiring “treatment”', N'Patient normally takes NSAID for arthritis but it is not charted as in-patient. Prescriber did not include strength of corticosteroid inhaler.')
GO
INSERT [dbo].[InterventionGrade] ([Value], [Description], [Example]) VALUES (2, N'An error that resulted in MINOR HARM to patient. Minor harm is that requiring minor (non-drug) treatment or treatment change.', N'Nurse found to be crushing sustained release metoprolol and administering down naso-gastric tube and patient had sudden drop in blood pressure')
GO
INSERT [dbo].[InterventionGrade] ([Value], [Description], [Example]) VALUES (3, N'An error that resulted in MODERATE HARM to patient.  Moderate harm is that requiring treatment with another drug OR cancellation/postponement of treatment.', N'Patient due for surgery but warfarin not stopped an appropriate time prior to surgery and surgery delayed as a result')
GO
INSERT [dbo].[InterventionGrade] ([Value], [Description], [Example]) VALUES (4, N'An error that resulted in MAJOR HARM to patient. Major harm is that requiring increased hospital stay or significant morbidity.', N'Patient administered amoxycillin when they have a clearly documented anaphylactic penicillin allergy and they have another anaphylactic reaction.')
GO
INSERT [dbo].[InterventionGrade] ([Value], [Description], [Example]) VALUES (5, N'An error that resulted in SERIOUS/CATASTROPHIC HARM to patient.', N'Patient administered intrathecal vincristine in error.')
GO
SET IDENTITY_INSERT [dbo].[Medications] ON 

GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (1, N'Abciximab', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (2, N'Acetazolamide', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (3, N'Acetic acid', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (4, N'Acetylcholine', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (5, N'Acetylcysteine', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (6, N'Aciclovir', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (7, N'Acitretin', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (8, N'Actinomycin-D', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (9, N'Activated charcoal', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (10, N'Adenosine', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (11, N'Adrenaline', 1)
GO
INSERT [dbo].[Medications] ([Id], [Name], [IsActive]) VALUES (12, N'ADT', 1)
GO
SET IDENTITY_INSERT [dbo].[Medications] OFF
GO
SET IDENTITY_INSERT [dbo].[Outcomes] ON 

GO
INSERT [dbo].[Outcomes] ([Id], [Value]) VALUES (1, N'Advice Followed')
GO
INSERT [dbo].[Outcomes] ([Id], [Value]) VALUES (2, N'Advice Ignored')
GO
INSERT [dbo].[Outcomes] ([Id], [Value]) VALUES (3, N'Unknown')
GO
SET IDENTITY_INSERT [dbo].[Outcomes] OFF
GO
SET IDENTITY_INSERT [dbo].[StaffTypes] ON 

GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (1, N'H/O')
GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (2, N'Registar')
GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (3, N'Consultant')
GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (4, N'Nurse')
GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (5, N'Midwife')
GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (6, N'Pharmacist')
GO
INSERT [dbo].[StaffTypes] ([Id], [Value]) VALUES (7, N'Other')
GO
SET IDENTITY_INSERT [dbo].[StaffTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Stages] ON 

GO
INSERT [dbo].[Stages] ([Id], [Value]) VALUES (1, N'Drug History')
GO
INSERT [dbo].[Stages] ([Id], [Value]) VALUES (2, N'Inpatient')
GO
INSERT [dbo].[Stages] ([Id], [Value]) VALUES (3, N'Discharge')
GO
SET IDENTITY_INSERT [dbo].[Stages] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeFrames] ON 

GO
INSERT [dbo].[TimeFrames] ([Id], [Value]) VALUES (1, N'< 5 minutes')
GO
INSERT [dbo].[TimeFrames] ([Id], [Value]) VALUES (2, N'5 - 15 minutes')
GO
INSERT [dbo].[TimeFrames] ([Id], [Value]) VALUES (3, N'16 - 30 minutes')
GO
INSERT [dbo].[TimeFrames] ([Id], [Value]) VALUES (4, N'> 30 minutes')
GO
SET IDENTITY_INSERT [dbo].[TimeFrames] OFF
GO
