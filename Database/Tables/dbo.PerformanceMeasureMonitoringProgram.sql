SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureMonitoringProgram](
	[PerformanceMeasureMonitoringProgramID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[MonitoringProgramID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureMonitoringProgram_PerformanceMeasureMonitoringProgramID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureMonitoringProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureMonitoringProgram_PerformanceMeasureID_MonitoringProgramID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureID] ASC,
	[MonitoringProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureMonitoringProgram]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureMonitoringProgram_MonitoringProgram_MonitoringProgramID] FOREIGN KEY([MonitoringProgramID])
REFERENCES [dbo].[MonitoringProgram] ([MonitoringProgramID])
GO
ALTER TABLE [dbo].[PerformanceMeasureMonitoringProgram] CHECK CONSTRAINT [FK_PerformanceMeasureMonitoringProgram_MonitoringProgram_MonitoringProgramID]
GO
ALTER TABLE [dbo].[PerformanceMeasureMonitoringProgram]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureMonitoringProgram_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureMonitoringProgram] CHECK CONSTRAINT [FK_PerformanceMeasureMonitoringProgram_PerformanceMeasure_PerformanceMeasureID]